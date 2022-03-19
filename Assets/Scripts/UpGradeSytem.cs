using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpGradeSytem : MonoBehaviour
{
    [HideInInspector]
    public int upgradeDoubleShootLevel;           // ������� Level DoubleShoot
    [HideInInspector]
    public int upgradeSpeedHeroLevel;             // ������� Level SpeedHero


    [Header("��������� ���� �������� DoubleShoot")]
    [SerializeField]
    private int startPriceDoubleShoot;
    [Header("��������� ���� �������� DoubleShoot")]
    [SerializeField]
    private int nextPriceDoubleShoot;

    [Header("��������� ���� �������� SpeedHero")]
    [SerializeField]
    private int startPriceSpeedHero;
    [Header("��������� ���� �������� SpeedHero")]
    [SerializeField]
    private int nextPriceSpeedHero;


    [SerializeField]
    private int currentPriceDoubleShoot;        // ������� ���� 
    [SerializeField]
    private int currentPriceSpeedHero;          // ������� ���� 


    [SerializeField]
    private int allMoney;                    // ��� ������



    void Start()
    {
        allMoney = GameController.Instance.allMoney;

        upgradeDoubleShootLevel = GameController.Instance.LoadData("upgradeDoubleShootLevel");
        upgradeSpeedHeroLevel = GameController.Instance.LoadData("upgradeSpeedHeroLevel");

        ShowUI();

    }

    //SaveData("Money", saveMoney);                                 // ��������� ����� �����
    //allMoney = LoadData("Money");


    /// <summary>
    /// �������� �������� 
    /// </summary>
    public void BuyUpgradeDoubleShoot()
    {
        if (allMoney > currentPriceDoubleShoot)
        {
            allMoney -= currentPriceDoubleShoot;
            upgradeDoubleShootLevel++;
            GameController.Instance.allMoney = allMoney;
            GameController.Instance.SaveData("upgradeDoubleShootLevel", upgradeDoubleShootLevel);
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
        currentPriceDoubleShoot = startPriceDoubleShoot + nextPriceDoubleShoot * upgradeDoubleShootLevel;
        currentPriceSpeedHero = startPriceSpeedHero + nextPriceSpeedHero * upgradeSpeedHeroLevel;

        GameController.Instance.upgradeDobleShootLevel = upgradeDoubleShootLevel;
        GameController.Instance.currentPriceDoubleShoot = currentPriceDoubleShoot;
        GameController.Instance.upgradeSpeedHeroLevel = upgradeSpeedHeroLevel;
        GameController.Instance.currentPriceSpeedHero = currentPriceSpeedHero;
    }

}
