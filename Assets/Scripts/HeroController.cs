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

    [SerializeField]
    private Material clothesBot;

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

    //[SerializeField]
    //[HideInInspector]
    public Material[] arrayMaterialClothes;         // ������ ������ � ������ �� �����

    void Start()
    {
        maxCountClothes = GameSettings.Instance.maxCountClothes;
        arrayMaterialClothes = new Material[maxCountClothes];
    }



    /// <summary>
    /// ����� ������
    /// </summary>
    /// <param name="materialClothes"></param>
    public void TakeClothes(Material materialClothes)
    {
        for (int index = 0; index < arrayMaterialClothes.Length; index++)
        {
            if (!arrayMaterialClothes[index])
            {
                arrayMaterialClothes[index] = materialClothes;
                clothesInHands.GetComponent<MeshRenderer>().material = materialClothes;

                break;
            }
        }
    }


    /// <summary>
    /// ��������� ������ �� ��������� ���� ���� �������
    /// </summary>
    public void CheckDoubleInArray()
    {
        for (int i = 0; i < arrayMaterialClothes.Length; i++)
        {
            for (int j = 0; j < arrayMaterialClothes.Length; j++)
            {
                if (i != j)
                {
                    if (arrayMaterialClothes[i] == arrayMaterialClothes[j] && arrayMaterialClothes[i] != null)
                    {
                        RemoveClothes(arrayMaterialClothes, i);
                    }
                }
                else
                {
                    continue;
                }
            }
        }
    }


    /// <summary>
    /// �������� ������ � ������
    /// </summary>
    /// <param name="arrayMaterialClothes"></param>
    /// <param name="index"></param>
    private void RemoveClothes(Material[] arrayMaterialClothes, int index)
    {
        print("Remove Clothes");
        arrayMaterialClothes[index] = null;
    }

    public void CompareClothes(Material clothesBot)
    {
        for (int index = 0; index < arrayMaterialClothes.Length; index++)
        {
            this.clothesBot = clothesBot;

            if (clothesBot == arrayMaterialClothes[index])
            {
                print(" Yes Clothes");
            }
        }
    }


}
