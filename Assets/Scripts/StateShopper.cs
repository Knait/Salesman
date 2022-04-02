using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    [SerializeField]
    private ShopperController shopperController;

    //[HideInInspector]
    public Transform currentTarget;   // текущая цель

    //[HideInInspector]
    public Transform currentStartPosition;

    //[SerializeField]
    //private CheckHeroBot checkHeroBot;

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
        timerBuy = GameSettings.Instance.startTimerWaitClient;
    }

    void Update()
    {
        UpdateStateShopper();
    }

    private void UpdateStateShopper()
    {
        switch (stateBot)
        {
            case StateBot.Start:

                break;

            case StateBot.Walk:
                shopperController.currentTarget = currentTarget;
                break;

            case StateBot.Buy:
                shopperController.currentTarget = null;
                break;

            case StateBot.Exit:
                shopperController.currentTarget = currentStartPosition;

                SetTimerUI();

                break;
        }
    }


    /// <summary>
    /// Состояние покупка
    /// </summary>
    public void SetStateBuy()
    {
        if (stateBot == StateBot.Walk)
        {
            StartCoroutine(TimerBuy(timerBuy));

            stateBot = StateBot.Buy;
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

    public float СalculationValueTimerUi()
    {
        float result = 0;

        result = countTimer / timerBuy;

        return result;
    }


    private void SetTimerUI()
    {
        StopCoroutine(showCalcTimer);
        countTimer = 0;
    }
}
