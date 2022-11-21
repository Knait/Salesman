using UnityEngine;

public class PointBuyCheckBot : MonoBehaviour
{
    /// <summary>
    /// тек. ID материал бота
    /// </summary>
    [HideInInspector]
    public int currentIDMaterialBot;
    /// <summary>
    /// тек. ID одежды бота
    /// </summary>
    public int currentIDClothesBot;

    [HideInInspector]
    public ShowClothesPointBuy showClothesPointBuy;
    [SerializeField]
    private ZoneCheckHero zoneCheckHero;
    [HideInInspector]
    public StateShopper stateShopper;

    private void Start()
    {
        zoneCheckHero = GetComponent<ZoneCheckHero>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Shopper shopper = other.GetComponent<Shopper>();
        stateShopper = other.GetComponent<StateShopper>();

        if (shopper)
        {
            currentIDMaterialBot = shopper.currentIDMaterialBot;
            currentIDClothesBot = shopper.currentIDClothesBot;
            showClothesPointBuy.SetActiveObject(currentIDClothesBot, currentIDMaterialBot);
        }

        if (stateShopper)
        {
            stateShopper.SetStateBuy();
        }
    }

    /// <summary>
    /// Чекаем бота
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        Shopper shopper = other.GetComponent<Shopper>();
        if (shopper)
        {
            currentIDClothesBot = 0;
            currentIDMaterialBot = 0;
            transform.GetComponent<PointBuy>().pointActive = false;          ///выкл точку покупки
            showClothesPointBuy.DeActiveObject();
        }
    }
}
