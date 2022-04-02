//говно скрипт висит на зоне чека игрока для подсветки

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneCheckHero : MonoBehaviour
{
    // [HideInInspector]
    public int currentIDMaterialBot;

    // [HideInInspector]
    public int currentIDClothesBot;

    [SerializeField]
    private PointBuyCheckBot pointBuyCheckBot;

    private void OnTriggerEnter(Collider other)
    {
        HeroController heroController = other.gameObject.GetComponent<HeroController>();

        if (heroController)
        {
            currentIDMaterialBot = pointBuyCheckBot.currentIDMaterialBot;
            currentIDClothesBot = pointBuyCheckBot.currentIDClothesBot;

            if (currentIDMaterialBot != 0)
            {
                int currentMoneyForBuy = heroController.CompareClothes(currentIDClothesBot, currentIDMaterialBot);

                if (currentMoneyForBuy != -1)
                {
                    //print(" hero In zone ");                   ////////////////////////////////////////
                    print(" Result Buy " + currentMoneyForBuy);
                    Buy(currentMoneyForBuy);
                }
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        HeroController heroController = other.gameObject.GetComponent<HeroController>();

        if (heroController)
        {


        }
    }

    /// <summary>
    /// Покупка
    /// </summary>
    private void Buy(int currentMoneyForBuy)
    {
        GameController.Instance.SetCountServedShoppers();

        GameController.Instance.SetCurrentMoney(currentMoneyForBuy);

        StateShopper stateShopper = pointBuyCheckBot.stateShopper;

        stateShopper.stateBot = StateBot.Exit;

    }



}
