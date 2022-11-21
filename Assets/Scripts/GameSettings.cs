using UnityEngine;

/// <summary>
/// ����� �� GameSettings ������ ��� ������������� ���������
/// </summary>
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
    [Header("��������� �������� ������� �������")]
    public float startDeltaComingClient;
    [Header("���������� ��������� ������� ������� �� ����������")]
    public float reductionDeltaComingClientHard;
    [Header("��������� ����� �������� �������")]
    public float startTimerWaitClient;
    [Header("������� ������� �� ������������")]
    public float timerAngry;
    [Header("���������� ������� �������� ������� �� ����������")]
    public float reductionTimerWaitClientHard;
    [Header("Default �������� ������")]
    public Material defaultMaterial;
    [Header("������ ���������� ������")]
    public Material[] arrayMaterial;
    [Header("������ ID ������")]
    public int[] arrayIDClothes;
    [Header("������� ������")]
    public Transform[] prefabShowClothes;

    private void Awake()
    {
        Instance = this;
        startTimerWaitClient -= GameController.Instance.currentLevel * reductionTimerWaitClientHard;
        startDeltaComingClient -= GameController.Instance.currentLevel * reductionDeltaComingClientHard;
    }
}






