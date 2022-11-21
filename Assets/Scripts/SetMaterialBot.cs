using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// висит на боте 
/// </summary>
public class SetMaterialBot : MonoBehaviour
{
    /// <summary>
    /// Текущий ID цвета бота
    /// </summary>
    [HideInInspector]
    public int IDMaterialClothes;

    private void OnEnable()
    {
        IDMaterialClothes = Random.Range(1, 5);
    }

}
