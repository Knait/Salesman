using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Скрипт висит на стойке с одежой
/// </summary>
public class StandController : MonoBehaviour
{
    [Header("Ссылка точки показа одежды")]
    [SerializeField]
    private Transform PointShowClothes;
    /// <summary>
    /// Таймер выдачи одежды
    /// </summary>
    [Header("Таймер выдачи одежды")]
    [SerializeField]
    private float timerGiveClothes;
    /// <summary>
    /// ID Стойки Одежды
    /// </summary>
    [Header("ID Стойки Одежды")]
    [SerializeField]
    private int IDClothes;
    /// <summary>
    /// Готов выдать одежу
    /// </summary>
    private bool isGiveClothes = true;

    void Start()
    {
        timerGiveClothes = GameSettings.Instance.timerGiveClothes;
        ShowClothes();
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
                isGiveClothes = false;
                StartCoroutine(TimerGiveClothes(timerGiveClothes));
                heroController.TakeClothes(IDClothes);
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


    /// <summary>
    /// Вкл одежду согласно IDClothes
    /// 
    /// </summary>
    private void ShowClothes()
    {
        Transform tempObj = Instantiate(GameSettings.Instance.prefabShowClothes[IDClothes - 1], PointShowClothes.position, Quaternion.Euler(90, 0, 0), PointShowClothes);
    }
}
