using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBuyCheckBot : MonoBehaviour
{

    [SerializeField]
    private ZoneCheckHero zoneCheckHero;

    private void Start()
    {
        zoneCheckHero = GetComponentInChildren<ZoneCheckHero>();
    }

    private void OnTriggerEnter(Collider other)
    {
        SetRandomMaterial setRandomMaterial = other.GetComponent<SetRandomMaterial>();

        CheckHeroBot checkHeroBot = other.GetComponent<CheckHeroBot>();

        StateShopper stateShopper = other.GetComponent<StateShopper>();

        //print(other.name);

        if (setRandomMaterial)
        {
            zoneCheckHero.currentIDMaterialBot = setRandomMaterial.IDMaterialClothes;
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
        SetRandomMaterial setRandomMaterial = other.GetComponent<SetRandomMaterial>();

        if (setRandomMaterial)
        {
            zoneCheckHero.currentIDMaterialBot = 0;
            //zoneCheckHero.transform.parent.gameObject.SetActive(false);
            zoneCheckHero.transform.parent.GetComponent<PointBuy>().pointActive = false;

        }
    }



}
