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
    public Transform currentTarget;   // ������� ����

    //[HideInInspector]
    public Transform currentStartPosition;

    //[SerializeField]
    //private CheckHeroBot checkHeroBot;

    [SerializeField]
    private float timerBuy;

    /// <summary>
    /// ������ UI �������
    /// </summary>
    [SerializeField]
    private float countTimer;   

    void Start()
    {
        shopperController = GetComponent<ShopperController>();
      //  checkHeroBot = GetComponent<CheckHeroBot>();
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
                break;
        }
    }


    /// <summary>
    /// ��������� �������
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
    /// ������ �������� �������
    /// </summary>
    /// <param name="timerBuy"></param>
    /// <returns></returns>
    private IEnumerator TimerBuy(float timerBuy)
    {
        Coroutine showCalcTimer = StartCoroutine(ShowCalcTimer());

        yield return new WaitForSeconds(timerBuy);

        StopCoroutine(showCalcTimer);
        countTimer = 0;
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
    /// ���� ������ �� ����� ����� ����
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

    public float �alculationValueTimerUi()
    {
        float result = 0;

        result = countTimer / timerBuy;

        return result;
    }
}
