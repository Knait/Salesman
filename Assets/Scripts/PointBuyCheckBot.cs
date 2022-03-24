using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBuyCheckBot : MonoBehaviour
{

    [SerializeField]
    private ZoneCheckHero zoneCheckHero;

    //[HideInInspector]
    public int currentIDMaterialBot;

    [SerializeField]
    private Renderer _renderer;

    [SerializeField]
    private Material defaultMaterial;


    private void Start()
    {
        zoneCheckHero = GetComponentInChildren<ZoneCheckHero>();
        _renderer = zoneCheckHero.GetComponent<Renderer>();
        defaultMaterial = _renderer.material;
    }

    private void OnTriggerEnter(Collider other)
    {
        SetMaterialBot setMaterialBot = other.GetComponent<SetMaterialBot>();

        CheckHeroBot checkHeroBot = other.GetComponent<CheckHeroBot>();

        StateShopper stateShopper = other.GetComponent<StateShopper>();

        //print(other.name);

        if (setMaterialBot)
        {
            //zoneCheckHero.currentIDMaterialBot = setRandomMaterial.IDMaterialClothes;

            currentIDMaterialBot = setMaterialBot.IDMaterialClothes;

            SetMaterialObject(GameSettings.Instance.arrayMaterial[currentIDMaterialBot]);
        }

        if (checkHeroBot)
        {
            checkHeroBot.zoneCheckHero = zoneCheckHero;
        }

        if (stateShopper)
        {
            stateShopper.SetStateBuy();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        SetMaterialBot setMaterialBot = other.GetComponent<SetMaterialBot>();

        if (setMaterialBot)
        {
            zoneCheckHero.currentIDMaterialBot = 0;
            //zoneCheckHero.transform.parent.gameObject.SetActive(false);
            zoneCheckHero.transform.parent.GetComponent<PointBuy>().pointActive = false;          ///выкл точку покупки
            //print("PointBuyCheckBot point false");
            SetMaterialObject();

        }
    }

    /// <summary>
    /// ¬кл выкл подсветки «оны
    /// </summary>
    /// <param name="stateObj"></param>
    public void SetMaterialObject(Material materialObj)
    {
        _renderer.material = materialObj;
    }

    /// <summary>
    /// выкл подсветки «оны
    /// </summary>
    /// <param name="stateObj"></param>
    public void SetMaterialObject()
    {
        _renderer.material = defaultMaterial;
    }

}
