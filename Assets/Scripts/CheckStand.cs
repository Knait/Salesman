// ����������� ����� �� ������
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStand : MonoBehaviour
{
    [Header("������ �� ����� � �����")]
    [SerializeField]
    private Transform clothesInHands;

    [Header("��� ���-�� ������")]
    private int maxCountClothes;

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

    private Material[] arrayMaterialClothes;

    void Start()
    {
        maxCountClothes = GameSettings.Instance.maxCountClothes;
        arrayMaterialClothes = new Material[maxCountClothes];
    }

    void Update()
    {

    }

    public void TakeClothes(Material materialClothes)
    {
        for(int index = 0; index < arrayMaterialClothes.Length; index++)
        {
            if (!arrayMaterialClothes[index])
            {
                arrayMaterialClothes[index] = materialClothes;
                clothesInHands.GetComponent<Renderer>().material = materialClothes;

                break;
            }

        }
    }

}
