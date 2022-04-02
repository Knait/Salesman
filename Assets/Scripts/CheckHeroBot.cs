using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHeroBot : CheckHero
{
   // [HideInInspector]
    public int currentIDMaterialBot;

   // [HideInInspector]
    public int currentIDClothesBot;

    [Header("Ссылка на модель визуала")]
    [SerializeField]
    private Transform skinModel;

    [SerializeField]
    private SetMaterialBot setMaterialBot;

    //[HideInInspector]
    public ZoneCheckHero zoneCheckHero;

    //[HideInInspector]
    public StateShopper stateShopper; 



    void Start()
    {
        setMaterialBot = GetComponent<SetMaterialBot>();
        stateShopper = GetComponent<StateShopper>();

        currentIDMaterialBot = setMaterialBot.IDMaterialClothes;

    }

    /// <summary>
    /// чекаем героя и проверяем у него одежду таково цвета
    /// </summary>
    /// <param name="heroController"></param>
    protected override void IsHero(HeroController heroController)
    {
       // print("Bot  Hero");                      //////////////////////////////////////////

        //currentIDMaterialBot = setMaterialBot.IDMaterialClothes;

        int currentMoneyForBuy = heroController.CompareClothes(currentIDClothesBot, currentIDMaterialBot);

       // if (currentIdClothes != 0)
      //  {
            Buy(currentMoneyForBuy);
      //  }
    }

    /// <summary>
    /// Покупка
    /// </summary>
    private void Buy(int currentMoneyForBuy)
    {
        //heroController.RemoveClothes(currentIdClothes);

        GameController.Instance.SetCountServedShoppers();

        GameController.Instance.SetCurrentMoney(currentMoneyForBuy);

        stateShopper.stateBot = StateBot.Exit;

        //zoneCheckHero.SetMaterialObject();
    }

}
