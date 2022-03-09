// ����������� ����� �� ������ � ������
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandController : MonoBehaviour
{
    [Header("������ ������ ������")]
    [SerializeField]
    private float timerGiveClothes = 2;

    //[SerializeField]
    private bool isGiveClothes = true;

    [HideInInspector]
    public Material materialStand;

    [SerializeField]
    public Color colorlStand;

    void Start()
    {
        materialStand = GetComponent<Renderer>().material;
        colorlStand = materialStand.color;
    }

    /// <summary>
    /// ������ ������
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay(Collision collision)
    {
        CheckStand checkStand = collision.gameObject.GetComponent<CheckStand>();

        if (checkStand)
        {
            if (isGiveClothes)
            {
                print(" Take Clothes");
                isGiveClothes = false;
                StartCoroutine(TimerGiveClothes(timerGiveClothes));
                checkStand.CountClothes++;
                checkStand.TakeClothes(materialStand);
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
