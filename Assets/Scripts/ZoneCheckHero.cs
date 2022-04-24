//говно скрипт висит на зоне чека игрока

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

    /// <summary>
    /// текущий материал проданой шмотки
    /// </summary>
    private int currentBuyIDMaterialClothes;

    [SerializeField]
    private ChangeSmile changeSmile;

    private void OnTriggerEnter(Collider other)
    {
        HeroController heroController = other.gameObject.GetComponent<HeroController>();

        if (heroController)
        {
            currentIDMaterialBot = pointBuyCheckBot.currentIDMaterialBot;
            currentIDClothesBot = pointBuyCheckBot.currentIDClothesBot;

            if (currentIDMaterialBot != 0)
            {
                int currentMoneyForBuy = heroController.CompareClothes(currentIDClothesBot, currentIDMaterialBot, out currentBuyIDMaterialClothes);

                if (currentMoneyForBuy != -1)
                {
                    //print(" hero In zone ");                   ////////////////////////////////////////
                    print(" Result Buy " + currentMoneyForBuy);
                    Buy(currentMoneyForBuy);

                    StateShopper stateShopper = pointBuyCheckBot.stateShopper;

                    changeSmile.ShowSmile(currentMoneyForBuy, stateShopper.transform);    //  смайлика



                }
            }
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

        stateShopper.SetStateBag(true, currentBuyIDMaterialClothes);

        if (currentMoneyForBuy == 10)
        {
            stateShopper.PlayParticle();
        }

        //pointBuyCheckBot.SetActiveParticeEffect(false, currentIDMaterialBot);

        pointBuyCheckBot.showClothesPointBuy.DeActiveObject();

        stateShopper.stateBot = StateBot.Exit;
    }

}
