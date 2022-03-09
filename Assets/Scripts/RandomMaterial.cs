using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterial : MonoBehaviour
{
    [Header("Массив материалов")]
    [SerializeField]
    private Material[] arrayMaterial;

    [Header("Ссылка на модель визуала")]
    [SerializeField]
    private Transform skinModel;

    void Start()
    {
       skinModel.GetComponent<SkinnedMeshRenderer>().materials[1] = arrayMaterial[0]; //arrayMaterial[Random.Range(0, arrayMaterial.Length)];

       // GetComponent<Renderer>().materials[1] = arrayMaterial[Random.Range(0, arrayMaterial.Length)];

    }

    void Update()
    {
        
    }
}
