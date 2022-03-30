
/// на боте 
/// 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaterialBot : MonoBehaviour
{
    [Header("Ссылка на модель визуала")]
    [SerializeField]
    private Transform skinModel;

    /// <summary>
    /// Текущий ID цвета бота
    /// </summary>
    //[HideInInspector]
    public int IDMaterialClothes;

    private void OnEnable()
    {
        IDMaterialClothes = Random.Range(1, 5);
    }


    /// <summary>
    /// Сетим ID материал одежды
    /// </summary>
    /// <param name="IDMaterialClothes"></param>
     void SetIDMaterialBot(int IDMaterialClothes)
    
    {
        Material[] arrayMaterial;

        arrayMaterial = GameSettings.Instance.arrayMaterial;

        this.IDMaterialClothes = IDMaterialClothes;

        Material[] copyArrayMaterials = skinModel.GetComponent<Renderer>().materials;

        copyArrayMaterials[1] = arrayMaterial[IDMaterialClothes];

        skinModel.GetComponent<Renderer>().materials = copyArrayMaterials;
    }

}
