using System.Collections;
using UnityEngine;

public class CheckHeroBasket : MonoBehaviour
{
    [Header("Ссылка в корзине ShowTakeMoney")]
    [SerializeField]
    private Transform UiShowTakeMoney;
    [Header("Таймер забора одежды")]
    [SerializeField]
    private float timerGiveClothes;
    [SerializeField]
    private bool isGiveClothes = true;

    void Start()
    {
        timerGiveClothes = GameSettings.Instance.timerGiveClothes;
        UiShowTakeMoney.gameObject.SetActive(false);
    }


    /// <summary>
    /// коротина таймер забора одежи
    /// </summary>
    /// <param name="timerGiveClothes"></param>
    /// <returns></returns>
    IEnumerator TimerGiveClothes(float timerGiveClothes)
    {
        yield return new WaitForSeconds(timerGiveClothes);
        isGiveClothes = true;
    }
}
