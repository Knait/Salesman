// на боте управление состоянием бота
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// состояния бота
/// </summary>
public enum StateBot
{
    Start,
    Walk,
    Buy,
    Exit
}

public class StateShopper : MonoBehaviour
{
    //[HideInInspector]
    public StateBot stateBot;

    [Header("Сылка на Сумку")]
    [SerializeField]
    private Transform bag;

    [SerializeField]
    private ShopperController shopperController;

    //[HideInInspector]
    public Transform currentTarget;   // текущая цель

    //[HideInInspector]
    public Transform currentStartPosition;

    [SerializeField]
    private float timerBuy;

    /// <summary>
    /// Таймер UI Таймера
    /// </summary>
    [SerializeField]
    private float countTimer;

    /// <summary>
    ///ССылка на корутину
    /// </summary>
    //[SerializeField]
    private Coroutine showCalcTimer;

    void Start()
    {
        shopperController = GetComponent<ShopperController>();

        timerBuy = GameSettings.Instance.startTimerWaitClient;          // время ожидания клиента
    }

    private void OnEnable()
    {
        SetStateBag(false, 1);             // выкл сумку
    }

    void Update()
    {
        UpdateStateShopper();
    }



    /// <summary>
    /// состояния покупателя
    /// </summary>
    private void UpdateStateShopper()
    {
        switch (stateBot)
        {
            case StateBot.Start:

                break;

            case StateBot.Walk: 
                shopperController.currentTarget = currentTarget;               // сетим цель покупателя на точку покупки
                break;

            case StateBot.Buy:
                shopperController.currentTarget = null;            // сброс цели покупателя
                break;

            case StateBot.Exit:
                shopperController.currentTarget = currentStartPosition;         // сетим цель покупателя на выход 
                 

                SetTimerUI();

                break;
        }
    }

    /// <summary>
    /// Вкл и красим сумку
    /// </summary>
    /// <param name="isActive">Вкл выкл </param>
    /// <param name="IDMaterialClothes">Цвет</param>
    public void SetStateBag(bool isActive, int IDMaterialClothes)
    {
        bag.gameObject.SetActive(isActive);     // вкл выкл сумки

        bag.GetComponent<MeshRenderer>().material = GameSettings.Instance.arrayMaterial[IDMaterialClothes];          // красим сумку
    }



    /// <summary>
    /// Состояние покупка
    /// </summary>
    public void SetStateBuy()
    {
        if (stateBot == StateBot.Walk)
        {
            StartCoroutine(TimerBuy(timerBuy));    ///вкл корутины покупки

            stateBot = StateBot.Buy;                  // сетим покупателя в Buy
        }
    }

    /// <summary>
    /// Таймер ожидания клиента
    /// </summary>
    /// <param name="timerBuy"></param>
    /// <returns></returns>
    private IEnumerator TimerBuy(float timerBuy)
    {
        showCalcTimer = StartCoroutine(ShowCalcTimer());

        yield return new WaitForSeconds(timerBuy);

        stateBot = StateBot.Exit;
    }

    /// <summary>
    /// корутина UI таймера
    /// </summary>
    /// <returns></returns>
    private IEnumerator ShowCalcTimer()
    {
        while (true)
        {
            countTimer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

    /// <summary>
    /// если пришел на спавн точку выкл
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        PointSpawn pointSpawn = other.GetComponent<PointSpawn>();

        if (pointSpawn)
        {
            if (stateBot == StateBot.Exit)
            {
                gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Расчет значения для UI таймера
    /// </summary>
    /// <returns></returns>
    public float СalculationValueTimerUi()
    {
        float result = 0;

        result = countTimer / timerBuy;

        return result;
    }

    /// <summary>
    /// обновляем UI таймер
    /// </summary>
    private void SetTimerUI()
    {
        StopCoroutine(showCalcTimer);
        countTimer = 0;
    }
}
