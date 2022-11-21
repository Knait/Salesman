using UnityEngine;

/// <summary>
///  ������ ����� �� ���� ���� ������
/// </summary>
public class ZoneCheckHero : MonoBehaviour
{
    [HideInInspector]
    public int currentIDMaterialBot;
    [HideInInspector]
    public int currentIDClothesBot;
    [HideInInspector]
    public int tempCurrentMoneyForBuy;

    [SerializeField]
    private PointBuyCheckBot pointBuyCheckBot;
    [SerializeField]
    private ChangeSmile changeSmile;
    /// <summary>
    /// ������� �������� �������� ������
    /// </summary>
    private int currentBuyIDMaterialClothes;
    private StateShopper stateShopper;

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
                    Buy(currentMoneyForBuy);
                    stateShopper = pointBuyCheckBot.stateShopper; // �������� ������� ����������
                    changeSmile.gameObject.SetActive(false);      // ��������� 
                    changeSmile.gameObject.SetActive(true);       //   ������ 
                    changeSmile.ShowSmile(tempCurrentMoneyForBuy, stateShopper.transform);    //  ��������

                }
            }
        }
    }


    /// <summary>
    /// �������
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
        pointBuyCheckBot.showClothesPointBuy.DeActiveObject();
        stateShopper.stateBot = StateBot.Exit;
    }
}
