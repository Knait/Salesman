using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpGradeSytem : MonoBehaviour
{
    /// <summary>
    /// текущий Level BonusMoney
    /// </summary>
    [HideInInspector]
    public int upgradeBonusMoneyLevel;           // текущий Level BonusMoney
    /// <summary>
    /// текущий Level SpeedHero
    /// </summary>
    [HideInInspector]
    public int upgradeSpeedHeroLevel;             // текущий Level SpeedHero


    [Header("Начальная цена прокачки BonusMoney")]
    [SerializeField]
    private int startPriceBonusMoney;
    [Header("Следующая цена прокачки BonusMoney")]
    [SerializeField]
    private int nextPriceBonusMoney;

    [Header("Начальная цена прокачки SpeedHero")]
    [SerializeField]
    private int startPriceSpeedHero;
    [Header("Следующая цена прокачки SpeedHero")]
    [SerializeField]
    private int nextPriceSpeedHero;


    [SerializeField]
    private int currentPriceBonusMoney;        // текущая цена 
    [SerializeField]
    private int currentPriceSpeedHero;          // текущая цена 


    [SerializeField]
    private int allMoney;                    // все деньхи



    void Start()
    {
        allMoney = GameController.Instance.allMoney;

        upgradeBonusMoneyLevel = GameController.Instance.LoadData("upgradeDoubleShootLevel");
        upgradeSpeedHeroLevel = GameController.Instance.LoadData("upgradeSpeedHeroLevel");

        ShowUI();

    }

    //SaveData("Money", saveMoney);                                 // сохраняем колво денег
    //allMoney = LoadData("Money");


    /// <summary>
    /// Покупаем прокачку 
    /// </summary>
    public void BuyUpgrade1()
    {
        if (allMoney > currentPriceBonusMoney)
        {
            allMoney -= currentPriceBonusMoney;
            upgradeBonusMoneyLevel++;
            GameController.Instance.allMoney = allMoney;
            GameController.Instance.SaveData("upgradeDoubleShootLevel", upgradeBonusMoneyLevel);
            GameController.Instance.SaveData("Money", allMoney);
            ShowUI();
        }
    }


    /// <summary>
    /// Покупаем прокачку 
    /// </summary>
    public void BuyUpgradeSpeedHero()
    {
        if (allMoney > currentPriceSpeedHero)
        {
            allMoney -= currentPriceSpeedHero;
            upgradeSpeedHeroLevel++;
            GameController.Instance.allMoney = allMoney;
            GameController.Instance.SaveData("upgradeSpeedHeroLevel", upgradeSpeedHeroLevel);
            GameController.Instance.SaveData("Money", allMoney);
            ShowUI();
        }
    }


    /// <summary>
    /// Показываем данные прокачки
    /// </summary>
    void ShowUI()
    {
        currentPriceBonusMoney = startPriceBonusMoney + nextPriceBonusMoney * upgradeBonusMoneyLevel;
        currentPriceSpeedHero = startPriceSpeedHero + nextPriceSpeedHero * upgradeSpeedHeroLevel;

        GameController.Instance.upgradeDobleShootLevel = upgradeBonusMoneyLevel;
        GameController.Instance.currentPriceDoubleShoot = currentPriceBonusMoney;
        GameController.Instance.upgradeSpeedHeroLevel = upgradeSpeedHeroLevel;
        GameController.Instance.currentPriceSpeedHero = currentPriceSpeedHero;
    }

}
