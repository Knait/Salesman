using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHeroBot : CheckHero
{
    [SerializeField]
    private Material currentMaterial;

    [Header("—сылка на модель визуала")]
    [SerializeField]
    private Transform skinModel;

    [SerializeField]
    private Material[] copyArrayMaterials;

    void Start()
    {
        copyArrayMaterials = skinModel.GetComponent<Renderer>().materials;
        currentMaterial = copyArrayMaterials[1];
    }

    protected override void MyMethod(HeroController heroController)
    {
        print("Bot  Hero");

        //copyArrayMaterials = heroController.arrayMaterialClothes;

        //for (int index = 0; index < heroController.arrayMaterialClothes.Length; index++)
        //{
        //    if (heroController.arrayMaterialClothes[index] == currentMaterial)
        //    {
        //        //heroController.arrayMaterialClothes[index] = materialClothes;
        //        print(" Yes Clothes");
        //    }
        //}

        heroController.CompareClothes(currentMaterial);

        //foreach(Material materialClothes in copyArrayMaterials)
        // {
        //     if (materialClothes == currentMaterial)
        //     {
        //         
        //     }
        // }




    }
}
