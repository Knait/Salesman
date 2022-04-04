// висит на UiController
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Обновление UI
/// </summary>
public class UiController : MonoBehaviour
{
    [Header("Cсылка UI кол-во  обсл-ых клиентов")]
    [SerializeField]
    private TMP_Text textCountServedShoppers;

    [Header("Cсылка UI таймер")]
    [SerializeField]
    private TMP_Text textCurrentTimer;

    [Header("Cсылка UI Level PanelStartGame")]
    [SerializeField]
    private TMP_Text textCurrentLevelPanelStartGame;

    [Header("Cсылка UI Level PanelLose")]
    [SerializeField]
    private TMP_Text textCurrentLevelPanelLose;

    [Header("Cсылка UI Level PanelWin")]
    [SerializeField]
    private TMP_Text textCurrentLevelPanelWin;

    [Header("Cсылка UI бабки PanelStartGame")]
    [SerializeField]
    private TMP_Text textMoneyPanelStartGame;

    [Header("Cсылка UI бабки PanelWin")]
    [SerializeField]
    private TMP_Text textMoneyPanelWin;

    [Header("Cсылка UI бабки PanelLose")]
    [SerializeField]
    private TMP_Text textMoneyPanelLose;

    [Header("Cсылка UI Все бабки PanelWin")]
    [SerializeField]
    private TMP_Text textAllMoneyPanelWin;

    [Header("Cсылка UI Все бабки PanelLose")]
    [SerializeField]
    private TMP_Text textAllMoneyPanelLose;

    [Header("Cсылка UI Upgrade 1 Level")]
    [SerializeField]
    private TMP_Text upgrade1level;

    [Header("Cсылка UI Upgrade 1 Price")]
    [SerializeField]
    private TMP_Text upgrade1Price;

    [Header("Cсылка UI Upgrade SpeedHero Level")]
    [SerializeField]
    private TMP_Text upgradeSpeedHeroLevel;

    [Header("Cсылка UI Upgrade SpeedHero Price")]
    [SerializeField]
    private TMP_Text upgradeSpeedHeroPrice;



    // Update is called once per frame
    void Update()
    {
        textCurrentLevelPanelStartGame.text = GameController.Instance.currentLevel.ToString();
        textMoneyPanelStartGame.text = GameController.Instance.allMoney.ToString();

        textCountServedShoppers.text = GameController.Instance.countServedShoppers.ToString();
        textCurrentTimer.text = GameController.Instance.currentTimerGame.ToString();

        

        textCurrentLevelPanelLose.text = GameController.Instance.currentLevel.ToString();
        textMoneyPanelLose.text = GameController.Instance.currentMoney.ToString();

        textAllMoneyPanelLose.text = GameController.Instance.allMoney.ToString();
        textAllMoneyPanelWin.text = GameController.Instance.allMoney.ToString();

        int textCurrentLevel = GameController.Instance.currentLevel - 1;        // показывать уровень на 1 меньше
        textCurrentLevelPanelWin.text = textCurrentLevel.ToString();
        textMoneyPanelWin.text = GameController.Instance.currentMoney.ToString();

        int tempLevel = GameController.Instance.upgradeDobleShootLevel + 1;
        upgrade1level.text = tempLevel.ToString();
        upgrade1Price.text = GameController.Instance.currentPriceDoubleShoot.ToString();
        tempLevel = GameController.Instance.upgradeSpeedHeroLevel + 1;
        upgradeSpeedHeroLevel.text = tempLevel.ToString();
        upgradeSpeedHeroPrice.text = GameController.Instance.currentPriceSpeedHero.ToString();
    }
}
