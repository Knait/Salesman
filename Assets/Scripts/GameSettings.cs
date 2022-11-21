using UnityEngine;

/// <summary>
/// висит на GameSettings хранит все настраиваемые параметры
/// </summary>
public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance;

    [Header("МАХ время игры")]
    public int maxTimeGame = 10;
    [Header("Начальная скорость игрока")]
    public  float speedStart;
    [Header("Значение Upgrade скорости прокачки")]
    public  float multiPlay;
    [Header("Мах кол-во одежды у игрока")]
    public int maxCountClothes;
    [Header("Таймер выдачи одежды")]
    public float timerGiveClothes;
    [Header("Кол - во бабла за покупку")]
    public int countMoneyBuy = 10;
    [Header("Кол - во бабла за игру")]
    public int countMoneyGame = 10;
    [Header("Кол - во бабла за выбрашенную одежку")]
    public int countMoneyRemove = 10;
    [Header("Начальный интервал прихода клиента")]
    public float startDeltaComingClient;
    [Header("Сокращение интервала прихода клиента со сложностью")]
    public float reductionDeltaComingClientHard;
    [Header("Начальное время ожидания клиента")]
    public float startTimerWaitClient;
    [Header("Сколько времени до недовольства")]
    public float timerAngry;
    [Header("Сокращение времени ожидания клиента со сложностью")]
    public float reductionTimerWaitClientHard;
    [Header("Default материал Одежды")]
    public Material defaultMaterial;
    [Header("Массив материалов Одежды")]
    public Material[] arrayMaterial;
    [Header("Массив ID Одежды")]
    public int[] arrayIDClothes;
    [Header("Префабы одежды")]
    public Transform[] prefabShowClothes;

    private void Awake()
    {
        Instance = this;
        startTimerWaitClient -= GameController.Instance.currentLevel * reductionTimerWaitClientHard;
        startDeltaComingClient -= GameController.Instance.currentLevel * reductionDeltaComingClientHard;
    }
}






