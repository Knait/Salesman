using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRandomMaterial : MonoBehaviour
{
    [Header("������ �� ������ �������")]
    [SerializeField]
    private Transform skinModel;

    /// <summary>
    /// ������� ID ����� ����
    /// </summary>
    //[HideInInspector]
    public int IDMaterialClothes;

    //private Material[] copyArrayMaterials;

    private void Start()
    {
        SetIDMaterialBot();
    }


    private void SetIDMaterialBot()
    {
        int startIndex = 1;

        Material[] arrayMaterial;

        arrayMaterial = GameSettings.Instance.arrayMaterial;

        IDMaterialClothes = Random.Range(startIndex, arrayMaterial.Length);

        Material[] copyArrayMaterials = skinModel.GetComponent<Renderer>().materials;

        copyArrayMaterials[1] = arrayMaterial[IDMaterialClothes];

        skinModel.GetComponent<Renderer>().materials = copyArrayMaterials;
    }

}
