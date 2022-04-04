using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpGradeSytem : MonoBehaviour
{
    /// <summary>
    /// ������� Level BonusMoney
    /// </summary>
    [HideInInspector]
    public int upgradeBonusMoneyLevel;           // ������� Level BonusMoney
    /// <summary>
    /// ������� Level SpeedHero
    /// </summary>
    [HideInInspector]
    public int upgradeSpeedHeroLevel;             // ������� Level SpeedHero


    [Header("��������� ���� �������� BonusMoney")]
    [SerializeField]
    private int startPriceBonusMoney;
    [Header("��������� ���� �������� BonusMoney")]
    [SerializeField]
    private int nextPriceBonusMoney;

    [Header("��������� ���� �������� SpeedHero")]
    [SerializeField]
    private int startPriceSpeedHero;
    [Header("��������� ���� �������� SpeedHero")]
    [SerializeField]
    private int nextPriceSpeedHero;


    [SerializeField]
    private int currentPriceBonusMoney;        // ������� ���� 
    [SerializeField]
    private int currentPriceSpeedHero;          // ������� ���� 


    [SerializeField]
    private int allMoney;                    // ��� ������



    void Start()
    {
        allMoney = GameController.Instance.allMoney;

        upgradeBonusMoneyLevel = GameController.Instance.LoadData("upgradeDoubleShootLevel");
        upgradeSpeedHeroLevel = GameController.Instance.LoadData("upgradeSpeedHeroLevel");

        ShowUI();

    }

    //SaveData("Money", saveMoney);                                 // ��������� ����� �����
    //allMoney = LoadData("Money");


    /// <summary>
    /// �������� �������� 
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
    /// �������� �������� 
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
    /// ���������� ������ ��������
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
