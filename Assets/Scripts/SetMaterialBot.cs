
/// �� ���� 
/// 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaterialBot : MonoBehaviour
{
    [Header("������ �� ������ �������")]
    [SerializeField]
    private Transform skinModel;

    /// <summary>
    /// ������� ID ����� ����
    /// </summary>
    //[HideInInspector]
    public int IDMaterialClothes;

    private void OnEnable()
    {
        IDMaterialClothes = Random.Range(1, 5);
    }


    /// <summary>
    /// ����� ID �������� ������
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
