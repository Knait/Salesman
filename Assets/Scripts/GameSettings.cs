
/// ����� �� GameSettings ������ ��� ������������� ���������
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance;

    [Header("��� ����� ����")]
    public int maxTimeGame = 10;

    [Header("��������� �������� ������")]
    public  float speedStart;

    [Header("�������� Upgrade �������� ��������")]
    public  float multiPlay;

    [Header("��� ���-�� ������ � ������")]
    public int maxCountClothes;


    [Header("������ ������ ������")]
    public float timerGiveClothes;

    [Header("��� - �� ����� �� �������")]
    public int countMoneyBuy = 10;

    [Header("��� - �� ����� �� ����")]
    public int countMoneyGame = 10;

    [Header("��� - �� ����� �� ����������� ������")]
    public int countMoneyRemove = 10;

    /// <summary>
    /// ��������� �������� ������� �������
    /// </summary>
    [Header("��������� �������� ������� �������")]
    public float startDeltaComingClient;

    [Header("�������� ������� ������� �� ����������")]
    public float deltaComingClientHard;

    [Header("���������� ��������� ������� ������� �� ����������")]
    public float reductionDeltaComingClientHard;

    /// <summary>
    /// ��������� ����� �������� �������
    /// </summary>
    [Header("��������� ����� �������� �������")]
    public float startTimerWaitClient;

    [Header("���������� ������� �������� ������� �� ����������")]
    public float reductionTimerWaitClientHard;

    [Header("Default �������� ������")]
    public Material defaultMaterial;

    [Header("������ ���������� ������")]
    public Material[] arrayMaterial;


    private void Awake()
    {
        Instance = this;
    }
    
}






