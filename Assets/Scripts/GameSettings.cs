using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance;

    [Header("��������� �������� ������")]
    public  float speedBegin;

    [Header("�������� Upgrade �������� ��������")]
    public  float multiPlay;

    [Header("��� ���-�� ������ � ������")]
    public int maxCountClothes;


    private void Awake()
    {
        Instance = this;
    }


}
