// ����� �� UiController
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// ���������� UI
/// </summary>
public class UiController : MonoBehaviour
{
    [Header("C����� UI ���-��  ����-�� ��������")]
    [SerializeField]
    private TMP_Text textCountServedShoppers;

    [Header("C����� UI ������")]
    [SerializeField]
    private TMP_Text textCurrentTimer;

    [Header("C����� UI Level PanelStartGame")]
    [SerializeField]
    private TMP_Text textCurrentLevelPanelStartGame;

    [Header("C����� UI Level PanelLose")]
    [SerializeField]
    private TMP_Text textCurrentLevelPanelLose;

    [Header("C����� UI Level PanelWin")]
    [SerializeField]
    private TMP_Text textCurrentLevelPanelWin;

    [Header("C����� UI ����� PanelStartGame")]
    [SerializeField]
    private TMP_Text textMoneyPanelStartGame;

    [Header("C����� UI ����� PanelWin")]
    [SerializeField]
    private TMP_Text textMoneyPanelWin;

    [Header("C����� UI ����� PanelLose")]
    [SerializeField]
    private TMP_Text textMoneyPanelLose;

    [Header("C����� UI ��� ����� PanelWin")]
    [SerializeField]
    private TMP_Text textAllMoneyPanelWin;

    [Header("C����� UI ��� ����� PanelLose")]
    [SerializeField]
    private TMP_Text textAllMoneyPanelLose;

    [Header("C����� UI Upgrade 1 Level")]
    [SerializeField]
    private TMP_Text upgrade1level;

    [Header("C����� UI Upgrade 1 Price")]
    [SerializeField]
    private TMP_Text upgrade1Price;

    [Header("C����� UI Upgrade SpeedHero Level")]
    [SerializeField]
    private TMP_Text upgradeSpeedHeroLevel;

    [Header("C����� UI Upgrade SpeedHero Price")]
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

        int textCurrentLevel = GameController.Instance.currentLevel - 1;        // ���������� ������� �� 1 ������
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
