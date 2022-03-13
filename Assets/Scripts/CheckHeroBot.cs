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



    void Start()
    {
        setRandomMaterial = GetComponent<SetRandomMaterial>();

    }

    protected override void IsHero(HeroController heroController)
    {
        print("Bot  Hero");

        currentIDMaterialBot = setRandomMaterial.IDMaterialClothes;


        heroController.CompareClothes(currentIDMaterialBot);
    }
}
