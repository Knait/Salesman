// ����������� ����� �� ������ � ������
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandController : MonoBehaviour
{
    [Header("������ ����� ������ ������")]
    [SerializeField]
    private Transform PointShowClothes;

    /// <summary>
    /// ������ ������ ������
    /// </summary>
    [Header("������ ������ ������")]
    [SerializeField]
    private float timerGiveClothes;

    /// <summary>
    /// ����� ������ �����
    /// </summary>
    private bool isGiveClothes = true;

    /// <summary>
    /// ID ������ ������
    /// </summary>
    [Header("ID ������ ������")]
    [SerializeField]
    private int IDClothes;

    void Start()
    {
        timerGiveClothes = GameSettings.Instance.timerGiveClothes;

        ShowClothes();
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
                // print(" Take Clothes");  /////////////////////////////////////////////////////
                isGiveClothes = false;
                StartCoroutine(TimerGiveClothes(timerGiveClothes));
                heroController.TakeClothes(IDClothes);
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


    /// <summary>
    /// ��� ������ �������� IDClothes
    /// 
    /// </summary>
    private void ShowClothes()
    {
        Transform tempObj = Instantiate(GameSettings.Instance.prefabShowClothes[IDClothes - 1], PointShowClothes.position, Quaternion.Euler(90, 0, 0), PointShowClothes);
    }
}
