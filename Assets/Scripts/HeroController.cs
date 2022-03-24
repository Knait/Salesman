// ����������� ����� �� ������
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HeroController : MonoBehaviour
{
    /// <summary>
    /// ����� �� ���������� ������
    /// </summary>
    [SerializeField]
    private int countMoneyClothes;

    /// <summary>
    /// ����� �� ���������� ����
    /// </summary>
    [SerializeField]
    private int countMoneyColor;

    [Header("������ �� ����� � �����")]
    [SerializeField]
    private Transform[] clothesInHands;

    [Header("��� ���-�� ������")]
    [SerializeField]
    private int maxCountClothes;

    /// <summary>
    /// ��������� �������� ����� ������
    /// </summary>
    [SerializeField]
    private Material defaultMaterial;


    //[SerializeField]
    public Clothes[] arrayClothes;       // ������ ������� ������ � ������ �� �����

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

    void Start()
    {
        maxCountClothes = GameSettings.Instance.maxCountClothes;

        arrayClothes = new Clothes[maxCountClothes];
        for (int index = 0; index < arrayClothes.Length; index++)
        {
            arrayClothes[index] = new Clothes();
        }

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

                Show�lothesInHands();

                break;
            }
        }
    }



    /// <summary>
    /// ������ ������
    /// </summary>
    /// <param name="IDMaterialClothes"></param>
    public void PaintingClothes(int IDMaterialClothes)
    {
        for (int index = 0; index < arrayClothes.Length; index++)
        {
            if (arrayClothes[index].IDClothes != 0)
            {
                arrayClothes[index].IDMaterialClothes = IDMaterialClothes;
            }
        }

        Show�lothesInHands();
    }





    /// <summary>
    /// ��������� ������ �� ��������� ���� ���� �������
    /// </summary>
    public bool CheckDoubleInArray()
    {
        bool result = false;

        //for (int i = 1; i < arrayIDMaterialClothes.Length; i++)
        //{
        //    if (arrayIDMaterialClothes[i] > 0)
        //    {
        //        RemoveClothes(i);
        //        result = true;
        //        break;
        //    }
        //    else
        //    {
        //        continue;
        //    }
        //}

        return result;
    }


    /// <summary>
    /// �������� ������ � ������
    /// </summary>
    /// <param name="arrayMaterialClothes"></param>
    /// <param name="index"></param>
    public void RemoveClothes(int index)
    {
        //print("Remove Clothes");                  /////////////////////////////////////////////////////
        // arrayIDMaterialClothes[index] = 0;

        arrayClothes[index].IDClothes = 0;
        arrayClothes[index].IDMaterialClothes = 0;

        Show�lothesInHands();
    }


    /// <summary>
    /// ���������� ������ ���� � � ������
    /// </summary>
    /// <param name="clothesBot"></param>
    public int CompareClothes(int currentIDClothesBot, int currentIDMaterialBot)
    {
        int result = 0;

        for (int index = 0; index < arrayClothes.Length; index++)
        {
            if (currentIDClothesBot == arrayClothes[index].IDClothes)
            {
                result += countMoneyClothes;
            }

            if (currentIDMaterialBot == arrayClothes[index].IDMaterialClothes)
            {
                result += countMoneyColor;
            }

            if (result > 0)
            {
                RemoveClothes(index);
                break;
            }
        }

        return result;
    }

    //public void Show�lothesInHands(int iDMaterialClothes)
    //{
    //    clothesInHands[].GetComponent<MeshRenderer>().material = GameSettings.Instance.arrayMaterial[iDMaterialClothes];
    //}




    /// <summary>
    /// ���������� ������ � ����� � ������
    /// </summary>
    public void Show�lothesInHands()
    {
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

    [System.Serializable]
    public class Clothes
    {
        public int IDClothes;
        public int IDMaterialClothes;
    }


}
