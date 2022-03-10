// ����������� ����� �� ������ � ������
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandController : MonoBehaviour
{
    [Header("������ ������ ������")]
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
    /// ������ ������
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
