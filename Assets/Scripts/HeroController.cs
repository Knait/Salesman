// ����������� ����� �� ������
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    [Header("������ �� ����� � �����")]
    [SerializeField]
    private Transform clothesInHands;

    [Header("��� ���-�� ������")]
    private int maxCountClothes;

    //[HideInInspector]
    public int[] arrayIDMaterialClothes;         // ������ ������ � ������ �� �����

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
        arrayIDMaterialClothes = new int[maxCountClothes + 1];
    }

    /// <summary>
    /// ����� ������
    /// </summary>
    /// <param name="materialClothes"></param>
    public void TakeClothes(int IDMaterialClothes)
    {
        for (int index = 1; index < arrayIDMaterialClothes.Length; index++)
        {
            if (arrayIDMaterialClothes[index] == 0)
            {
                arrayIDMaterialClothes[index] = IDMaterialClothes;
                clothesInHands.GetComponent<MeshRenderer>().material = GameSettings.Instance.arrayMaterial[IDMaterialClothes];

                break;
            }
        }
    }


    /// <summary>
    /// ��������� ������ �� ��������� ���� ���� �������
    /// </summary>
    public bool CheckDoubleInArray()
    {
        bool result = false;

        for (int i = 1; i < arrayIDMaterialClothes.Length; i++)
        {
            for (int j = 1; j < arrayIDMaterialClothes.Length; j++)
            {
                if (i != j)
                {
                    if (arrayIDMaterialClothes[i] == arrayIDMaterialClothes[j] && arrayIDMaterialClothes[i] > 0)
                    {
                        RemoveClothes(arrayIDMaterialClothes, i);
                        result = true;
                        break;
                    }
                }
                else
                {
                    continue;
                }
            }
        }

        return result;
    }


    /// <summary>
    /// �������� ������ � ������
    /// </summary>
    /// <param name="arrayMaterialClothes"></param>
    /// <param name="index"></param>
    private void RemoveClothes(int[] arrayMaterialClothes, int index)
    {
        print("Remove Clothes");
        arrayMaterialClothes[index] = 0;
    }


    /// <summary>
    /// ���������� ������ ���� � � ������
    /// </summary>
    /// <param name="clothesBot"></param>
    public int CompareClothes(int clothesBot)
    {
        int result = 0;

        for (int index = 1; index < arrayIDMaterialClothes.Length; index++)
        {
            if (clothesBot == arrayIDMaterialClothes[index])
            {
                print(" Yes Clothes");
                result = index;
            }
        }

        return result;
    }


}
