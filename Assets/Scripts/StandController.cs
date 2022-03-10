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

    [HideInInspector]
    public Material materialStand;

    [SerializeField]
    public Color colorlStand;

    void Start()
    {
        timerGiveClothes = GameSettings.Instance.timerGiveClothes;
        materialStand = GetComponent<Renderer>().material;
        colorlStand = materialStand.color;
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
                heroController.TakeClothes(materialStand);
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





}
