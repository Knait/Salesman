using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHeroBot : CheckHero
{
    [SerializeField]
    private int currentIDMaterialBot;

    [Header("Ссылка на модель визуала")]
    [SerializeField]
    private Transform skinModel;

    [SerializeField]
    private SetRandomMaterial setRandomMaterial;

    //[HideInInspector]
    public ZoneCheckHero zoneCheckHero;

    //[HideInInspector]
    public StateShopper stateShopper; 



    void Start()
    {
        setRandomMaterial = GetComponent<SetRandomMaterial>();
        stateShopper = GetComponent<StateShopper>();

    }

    /// <summary>
    /// чекаем героя и проверяем у него одежду таково цвета
    /// </summary>
    /// <param name="heroController"></param>
    protected override void IsHero(HeroController heroController)
    {
        print("Bot  Hero");

        currentIDMaterialBot = setRandomMaterial.IDMaterialClothes;

        int currentIdClothes = heroController.CompareClothes(currentIDMaterialBot);

        if (currentIdClothes != 0)
        {
            Buy(heroController, currentIdClothes);
        }
    }

    /// <summary>
    /// Покупка
    /// </summary>
    private void Buy(HeroController heroController, int currentIdClothes)
    {
        heroController.RemoveClothes(currentIdClothes);

        GameController.Instance.countServedShoppers++;

        stateShopper.stateBot = StateBot.Exit;

        zoneCheckHero.SetMaterialObject();
    }

}
