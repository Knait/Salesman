using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ����� �� ������
/// </summary>
public class HeroController : MonoBehaviour
{
    /// <summary>
    /// ����� ����� �� ���������� ������
    /// </summary>
    [SerializeField]
    private int countMoneyClothes;

    /// <summary>
    /// ����� ����� �� ���������� ����
    /// </summary>
    [SerializeField]
    private int countMoneyColor;

    /// <summary>
    /// ������ ������������ �� ������
    /// </summary>
    [Header("ShowCongratulation �� ������")]
    [SerializeField]
    private PointShowCongratilation showCongratulation;

    /// <summary>
    /// ������ ������ �� ����� � �����
    /// </summary>
    [Header("������ ������ �� ����� � �����")]
    [SerializeField]
    private Transform[] clothesInHands;

    /// <summary>
    /// ��� ���-�� ������
    /// </summary>
    [Header("��� ���-�� ������")]
    [SerializeField]
    private int maxCountClothes;

    /// <summary>
    /// ��������� �������� ����� ������
    /// </summary>
    [SerializeField]
    private Material defaultMaterial;

    /// <summary>
    /// ������ ������� ������ � ������ �� �����
    /// </summary>
    public Clothes[] arrayClothes;

    /// <summary>
    /// ����� ����� � �����
    /// </summary>
    [SerializeField]
    private int countClothes;
    public int CountClothes
    {
        get
        {
            return countClothes;
        }
        set
        {
            if (value <= maxCountClothes)  // ���� ������� �� �������
            {
                countClothes = value;
            }
            else
            {
                countClothes = maxCountClothes;  // �� ���-�� ����� ��� ��������
            }
        }
    }

    [SerializeField]
    private MoveController moveController;

    void Start()
    {
        moveController = GetComponent<MoveController>();
        maxCountClothes = GameSettings.Instance.maxCountClothes;
        defaultMaterial = clothesInHands[0].GetComponent<MeshRenderer>().material;
        Show�lothesInHands();
    }

    /// <summary>
    /// ����� ������
    /// </summary>
    /// <param name="materialClothes"></param>
    public void TakeClothes(int IDClothes)
    {
        for (int index = 0; index < arrayClothes.Length; index++)
        {
            if (arrayClothes[index].IDClothes == 0)
            {
                arrayClothes[index].IDClothes = IDClothes;
                arrayClothes[index].clatch.gameObject.SetActive(true);
                arrayClothes[index].clatch.color = Color.white;
                countClothes++;
                Show�lothesInHands();
                break;
            }
        }
    }



    /// <summary>
    /// ������ ������
    /// </summary>
    /// <param name="IDMaterialClothes"></param>
    public bool PaintingClothes(int IDMaterialClothes)
    {
        bool result = false;

        for (int index = 0; index < arrayClothes.Length; index++)
        {
            if (arrayClothes[index].IDClothes != 0)
            {
                arrayClothes[index].IDMaterialClothes = IDMaterialClothes;
                arrayClothes[index].clatch.color = GameSettings.Instance.arrayMaterial[arrayClothes[index].IDMaterialClothes].color;
                result = true;
            }
        }
        Show�lothesInHands();
        return result;
    }

    /// <summary>
    /// �������� ������ � ������
    /// </summary>
    /// <param name="arrayMaterialClothes"></param>
    /// <param name="index"></param>
    public void RemoveClothes(int index)
    {
        arrayClothes[index].IDClothes = 0;
        arrayClothes[index].IDMaterialClothes = 0;
        arrayClothes[index].clatch.color = Color.white;
        arrayClothes[index].clatch.gameObject.SetActive(false);
        countClothes--;
        Show�lothesInHands();
    }


    /// <summary>
    /// ���������� ������ ���� � ������
    /// </summary>
    /// <param name="clothesBot"></param>
    public int CompareClothes(int currentIDClothesBot, int currentIDMaterialBot, out int currentBuyIDMaterialClothes)
    {
        currentBuyIDMaterialClothes = 0;
        int indexArrayClothes = 0;
        int result = 0;
        int[] resultTemp = new int[2];

        if (countClothes > 0)
        {
            for (int index = 0; index < arrayClothes.Length; index++)
            {
                if (currentIDClothesBot == arrayClothes[index].IDClothes)
                {
                    resultTemp[index] += countMoneyClothes;
                }
                if (currentIDMaterialBot == arrayClothes[index].IDMaterialClothes)
                {
                    resultTemp[index] += countMoneyColor;
                }
            }

            if (resultTemp[0] > resultTemp[1])
            {
                result = resultTemp[0];
                indexArrayClothes = 0;
            }
            else if (arrayClothes[0].IDClothes != 0)
            {
                result = resultTemp[0];
                indexArrayClothes = 0;
            }
            else
            {
                result = resultTemp[1];
                indexArrayClothes = 1;
            }
            currentBuyIDMaterialClothes = arrayClothes[indexArrayClothes].IDMaterialClothes;   //����� ID �������� ��������� ������
            RemoveClothes(indexArrayClothes);                                                  // ������� �� ������� ������ ������ ������ ������� ������
        }
        else
        {
            result = -1;                    // ������ �� �������
        }

        showCongratulation.ShowCongratulate(result);
        return result;
    }

    /// <summary>
    /// ���������� ������ � ����� � ������
    /// </summary>
    public void Show�lothesInHands()
    {
        moveController.SetAnimatorWithBox(countClothes > 0);                  // ����� ��������� ��������� � ��������
        for (int index = 0; index < arrayClothes.Length; index++)
        {
            if (arrayClothes[index].IDClothes != 0)
            {
                clothesInHands[index].gameObject.SetActive(true);
                if (arrayClothes[index].IDMaterialClothes != 0)
                {
                    clothesInHands[index].GetComponent<MeshRenderer>().material = GameSettings.Instance.arrayMaterial[arrayClothes[index].IDMaterialClothes];
                }
                else
                {
                    clothesInHands[index].GetComponent<MeshRenderer>().material = defaultMaterial;
                }
            }
            else
            {
                clothesInHands[index].gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// ������ �������� ��� ������� UI
    /// </summary>
    /// <returns></returns>
    public float �alculationValueTimerUi()
    {
        float result = 0;
        result = (float)countClothes / maxCountClothes;
        return result;
    }

    /// <summary>
    /// ����� ������
    /// </summary>
    [System.Serializable]
    public class Clothes
    {
        /// <summary>
        /// ID ������
        /// </summary>
        public int IDClothes;

        /// <summary>
        /// ID ���������� ������ 
        /// </summary>
        public int IDMaterialClothes;
        public Image clatch;
    }
}
