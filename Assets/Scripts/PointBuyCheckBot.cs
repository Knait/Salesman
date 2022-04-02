using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBuyCheckBot : MonoBehaviour
{
    /// <summary>
    /// тек. ID материал бота
    /// </summary>
    //[HideInInspector]
    public int currentIDMaterialBot;

    /// <summary>
    /// тек. ID одежды бота
    /// </summary>
    public int currentIDClothesBot;

    [SerializeField]
    private ShowClothesPointBuy showClothesPointBuy;

    [Header("—сылка на Particle Effect")]
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
    /// „екаем бота
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        Shopper shopper = other.GetComponent<Shopper>();

        if (shopper)
        {
            currentIDClothesBot = 0;
            currentIDMaterialBot = 0;

            transform.GetComponent<PointBuy>().pointActive = false;          ///выкл точку покупки

            showClothesPointBuy.DeActiveObject();
            particleEffect.gameObject.SetActive(false);
        }
    }

}
