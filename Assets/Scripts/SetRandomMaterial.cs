using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRandomMaterial : MonoBehaviour
{
    [Header("������ ����������")]
    [SerializeField]
    private Material[] arrayMaterial;

    [Header("������ �� ������ �������")]
    [SerializeField]
    private Transform skinModel;

    private Material[] copyArrayMaterials;


    private void Awake()
    {
        copyArrayMaterials = skinModel.GetComponent<Renderer>().materials;

        copyArrayMaterials[1] = arrayMaterial[Random.Range(0, arrayMaterial.Length)];

        skinModel.GetComponent<Renderer>().materials = copyArrayMaterials;
    }
    private void Start()
    {
        
    }
}
