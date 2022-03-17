using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHeroBasket : MonoBehaviour
{
    [Header("������ � ������� ShowTakeMoney")]
    [SerializeField]
    private Transform UiShowTakeMoney;

    [Header("������ ������ ������")]
    [SerializeField]
    private float timerGiveClothes;

    [SerializeField]
    private bool isGiveClothes = true;

    void Start()
    {
        timerGiveClothes = GameSettings.Instance.timerGiveClothes;
        UiShowTakeMoney.gameObject.SetActive(false);

    }

    //protected override void IsHero(HeroController heroController)
    //{
    //    print("Basket  Hero");

    //    if (heroController.CheckDoubleInArray())
    //    {
    //        UiShowTakeMoney.gameObject.SetActive(true);
    //    }
    //}


    /// <summary>
    /// ������ ������
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay(Collision collision)
    {
        HeroController heroController = collision.gameObject.GetComponent<HeroController>();

        if (heroController)
        {
            print("Basket  Hero");

            if (isGiveClothes)
            {
                if (heroController.CheckDoubleInArray())
                {
                    UiShowTakeMoney.gameObject.SetActive(true);
                    isGiveClothes = false;
                    StartCoroutine(TimerGiveClothes(timerGiveClothes));
                }

                //        print(" Take Clothes");
                //        isGiveClothes = false;
                //        StartCoroutine(TimerGiveClothes(timerGiveClothes));
                //        heroController.CountClothes++;
                //        heroController.TakeClothes(IDMaterialClothes);
            }
        }



    }


    /// <summary>
    /// ��������� ������ ������ �����
    /// </summary>
    /// <param name="timerGiveClothes"></param>
    /// <returns></returns>
    IEnumerator TimerGiveClothes(float timerGiveClothes)
    {
        yield return new WaitForSeconds(timerGiveClothes);
        isGiveClothes = true;
    }
}
