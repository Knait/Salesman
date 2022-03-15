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
    /// ������ ����� � ��������� � ���� ������ ������ �����
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
    /// �������
    /// </summary>
    private void Buy(HeroController heroController, int currentIdClothes)
    {
        heroController.RemoveClothes(currentIdClothes);

        GameController.Instance.countServedShoppers++;

        stateShopper.stateBot = StateBot.Exit;

        zoneCheckHero.SetMaterialObject();
    }

}
