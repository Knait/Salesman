using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBuyCheckBot : MonoBehaviour
{
    /// <summary>
    /// ���. ID �������� ����
    /// </summary>
    //[HideInInspector]
    public int currentIDMaterialBot;

    /// <summary>
    /// ���. ID ������ ����
    /// </summary>
    public int currentIDClothesBot;

    [SerializeField]
    private ShowClothesPointBuy showClothesPointBuy;

    [Header("������ �� Particle Effect")]
    [SerializeField]
    private Transform particleEffect;

    [SerializeField]
    private Color currentColor;

    private ParticleSystem particleSys;

    [HideInInspector]
    public StateShopper stateShopper;




    private void Start()
    {
        particleSys = particleEffect.GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {

        Shopper shopper = other.GetComponent<Shopper>();

        stateShopper = other.GetComponent<StateShopper>();

        if (shopper)
        {
            currentIDMaterialBot = shopper.currentIDMaterialBot;
            currentIDClothesBot = shopper.currentIDClothesBot;

            showClothesPointBuy.SetActiveObject(currentIDClothesBot);
           
            particleEffect.gameObject.SetActive(true);
            currentColor = GameSettings.Instance.arrayMaterial[currentIDMaterialBot].color;
            particleSys.startColor = currentColor;
        }

        if (stateShopper)
        {
            stateShopper.SetStateBuy();
        }
    }


    /// <summary>
    /// ������ ����
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        Shopper shopper = other.GetComponent<Shopper>();

        if (shopper)
        {
            currentIDClothesBot = 0;
            currentIDMaterialBot = 0;

            transform.GetComponent<PointBuy>().pointActive = false;          ///���� ����� �������

            showClothesPointBuy.DeActiveObject();
            particleEffect.gameObject.SetActive(false);
        }
    }

}
