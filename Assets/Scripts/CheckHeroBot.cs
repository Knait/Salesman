using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHeroBot : CheckHero
{
    [SerializeField]
    private int currentIDMaterialBot;

    [Header("������ �� ������ �������")]
    [SerializeField]
    private Transform skinModel;

    [SerializeField]
    private SetRandomMaterial setRandomMaterial;

    [SerializeField]
    public ZoneCheckHero zoneCheckHero;

    void Start()
    {
        setRandomMaterial = GetComponent<SetRandomMaterial>();
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

            zoneCheckHero.SetMaterialObject();
        }
    }

}