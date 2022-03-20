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

    [SerializeField]
    private CheckHeroBot checkHeroBot;

    [SerializeField]
    private float timerBuy;

    // Start is called before the first frame update
    void Start()
    {
        shopperController = GetComponent<ShopperController>();
        checkHeroBot = GetComponent<CheckHeroBot>();
    }

    // Update is called once per frame
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
    /// Состояние покупка
    /// </summary>
    public void SetStateBuy()
    {
        if (stateBot == StateBot.Walk)
        {

            timerBuy = GameSettings.Instance.startTimerWaitClient;
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
        yield return new WaitForSeconds(timerBuy);
        stateBot = StateBot.Exit;

        //checkHeroBot.zoneCheckHero.transform.parent.gameObject.SetActive(false);
        // checkHeroBot.zoneCheckHero.transform.parent.GetComponent<PointBuy>().pointActive = false;
       // print("Stateshopper point false");

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
}
