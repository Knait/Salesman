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

    [Header("������ ������ ������")]
    public float timerGiveClothes;

    [Header("������ ���������� ������")]
    public Material[] arrayMaterial;


    private void Awake()
    {
        Instance = this;
    }


}
