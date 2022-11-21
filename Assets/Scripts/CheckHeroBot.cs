using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHeroBot : CheckHero
{
    [HideInInspector]
    public int currentIDMaterialBot;
    [HideInInspector]
    public int currentIDClothesBot;
    [HideInInspector]
    public ZoneCheckHero zoneCheckHero;
    [HideInInspector]
    public StateShopper stateShopper;
    [Header("Ссылка на модель визуала")]
    [SerializeField]
    private Transform skinModel;
    private SetMaterialBot setMaterialBot;


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
        int currentMoneyForBuy = heroController.CompareClothes(currentIDClothesBot, currentIDMaterialBot, out int currentBuyIDMaterialClothes);
        Buy(currentMoneyForBuy);
    }

    /// <summary>
    /// Покупка
    /// </summary>
    private void Buy(int currentMoneyForBuy)
    {
        GameController.Instance.SetCountServedShoppers();
        GameController.Instance.SetCurrentMoney(currentMoneyForBuy);
        stateShopper.stateBot = StateBot.Exit;
    }
}
