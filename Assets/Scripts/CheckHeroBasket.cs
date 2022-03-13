using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHeroBasket : CheckHero
{
    [Header("—сылка в корзине ShowTakeMoney")]
    [SerializeField]
    private Transform UiShowTakeMoney;

    void Start()
    {
        UiShowTakeMoney.gameObject.SetActive(false);

    }

    protected override void IsHero(HeroController heroController)
    {
        print("Basket  Hero");

        if (heroController.CheckDoubleInArray())
        {
            UiShowTakeMoney.gameObject.SetActive(true);
        }
    }
}
