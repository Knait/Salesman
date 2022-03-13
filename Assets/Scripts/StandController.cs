// ГамноСкрипт висит на стойке с одежой
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandController : MonoBehaviour
{
    [Header("Таймер выдачи одежды")]
    [SerializeField]
    private float timerGiveClothes;

    //[SerializeField]
    private bool isGiveClothes = true;

    [Header("ID материала Стойки Одежды")]
    [SerializeField]
    private int IDMaterialClothes;

    //[HideInInspector]
    //public Material materialStand;

    void Start()
    {
        timerGiveClothes = GameSettings.Instance.timerGiveClothes;

        SetIDMaterialStand();
    }

    /// <summary>
    /// чекаем игрока
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay(Collision collision)
    {
        HeroController heroController = collision.gameObject.GetComponent<HeroController>();

        if (heroController)
        {
            if (isGiveClothes)
            {
                print(" Take Clothes");
                isGiveClothes = false;
                StartCoroutine(TimerGiveClothes(timerGiveClothes));
                heroController.CountClothes++;
                heroController.TakeClothes(IDMaterialClothes);
            }
        }
    }


    /// <summary>
    /// скоротина таймер выдачи одежи
    /// </summary>
    /// <param name="timerGiveClothes"></param>
    /// <returns></returns>
    IEnumerator TimerGiveClothes(float timerGiveClothes)
    {
        yield return new WaitForSeconds(timerGiveClothes);
        isGiveClothes = true;
    }


    private void SetIDMaterialStand()
    {
        Material[] arrayMaterial;

        arrayMaterial = GameSettings.Instance.arrayMaterial;

        GetComponent<Renderer>().material = arrayMaterial[IDMaterialClothes];

        //IDMaterialClothes = Random.Range(0, arrayMaterial.Length);

        //Material[] copyArrayMaterials = skinModel.GetComponent<Renderer>().materials;

        //copyArrayMaterials[1] = 

        //skinModel.GetComponent<Renderer>().materials = copyArrayMaterials;
    }


}
