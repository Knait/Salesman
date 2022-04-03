
/// на боте 
/// 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaterialBot : MonoBehaviour
{
    //[Header("Ссылка на модель визуала")]
    //[SerializeField]
    //private Transform skinModel;

    /// <summary>
    /// Текущий ID цвета бота
    /// </summary>
    //[HideInInspector]
    public int IDMaterialClothes;

    private void OnEnable()
    {
        IDMaterialClothes = Random.Range(1, 5);
    }

}
