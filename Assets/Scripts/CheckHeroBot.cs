using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHeroBot : CheckHero
{
    [SerializeField]
    private int currentIDMaterialBot;

    [Header("—сылка на модель визуала")]
    [SerializeField]
    private Transform skinModel;

    [SerializeField]
    private SetRandomMaterial setRandomMaterial;

    [SerializeField]
    private ZoneCheckHero zoneCheckHero;

    void Start()
    {
        setRandomMaterial = GetComponent<SetRandomMaterial>();

        zoneCheckHero = GetComponentInChildren<ZoneCheckHero>();

    }

    protected override void IsHero(HeroController heroController)
    {
        print("Bot  Hero");

        currentIDMaterialBot = setRandomMaterial.IDMaterialClothes;

        int currentIdClothes = heroController.CompareClothes(currentIDMaterialBot);

        if (currentIdClothes != 0)
        {
            heroController.RemoveClothes(currentIdClothes);

            GameController.Instance.countServedShoppers++;

            zoneCheckHero.SetStateObject(false);
        }
    }

}
