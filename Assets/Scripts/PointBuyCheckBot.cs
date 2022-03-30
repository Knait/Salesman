using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBuyCheckBot : MonoBehaviour
{

    //[SerializeField]
    //private ZoneCheckHero zoneCheckHero;

    /// <summary>
    /// тек. ID материал бота
    /// </summary>
    //[HideInInspector]
    public int currentIDMaterialBot;

    /// <summary>
    /// тек. ID одежды бота
    /// </summary>
    public int currentIDClothesBot;

    [SerializeField]
    private Renderer _renderer;

    [SerializeField]
    private Material defaultMaterial;

    [SerializeField]
    private ShowClothesPointBuy showClothesPointBuy;


    private void Start()
    {
        //zoneCheckHero = GetComponentInChildren<ZoneCheckHero>();
        //_renderer = zoneCheckHero.GetComponent<Renderer>();
        //defaultMaterial = _renderer.material;
    }

    private void OnTriggerEnter(Collider other)
    {

        Shopper shopper = other.GetComponent<Shopper>();

        StateShopper stateShopper = other.GetComponent<StateShopper>();

        if (shopper)
        {
            //checkHeroBot.zoneCheckHero = zoneCheckHero;

            currentIDMaterialBot = shopper.currentIDMaterialBot;

            currentIDClothesBot = shopper.currentIDClothesBot;

           // SetMaterialObject(GameSettings.Instance.arrayMaterial[currentIDMaterialBot]);

            showClothesPointBuy.SetActiveObject(currentIDClothesBot);

        }

        if (stateShopper)
        {
            stateShopper.SetStateBuy();
        }
    }


    /// <summary>
    /// „екаем бота
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        Shopper shopper = other.GetComponent<Shopper>();

        if (shopper)
        {
            currentIDClothesBot = 0;

            currentIDMaterialBot = 0;

            //zoneCheckHero.transform.parent.GetComponent<PointBuy>().pointActive = false;          ///выкл точку покупки
            showClothesPointBuy.DeActiveObject();

            SetMaterialObject();

        }
    }

    /// <summary>
    /// ¬кл выкл подсветки «оны
    /// </summary>
    /// <param name="materialObj"></param>
    public void SetMaterialObject(Material materialObj)
    {
        _renderer.material = materialObj;
    }

    /// <summary>
    ///  выкл подсветки «оны
    /// </summary>
    public void SetMaterialObject()
    {
        //_renderer.material = defaultMaterial;
    }

}
