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

    //[HideInInspector]
    public ShowClothesPointBuy showClothesPointBuy;

    [Header("Ссылка на Particle Effect")]
    [SerializeField]
    private Transform particleEffect;

    /// <summary>
    /// Текущий материал у бота
    /// </summary>
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

            SetActiveParticeEffect(true);
            currentColor = GameSettings.Instance.arrayMaterial[currentIDMaterialBot].color;
            particleSys.startColor = currentColor;
        }

        if (stateShopper)
        {
            stateShopper.SetStateBuy();
        }
    }


    /// <summary>
    /// Чекаем бота
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
            SetActiveParticeEffect(false);
        }
    }


    /// <summary>
    /// вкл выкл партиклов
    /// </summary>
    /// <param name="isActive"></param>
    public void SetActiveParticeEffect(bool isActive)
    {
        particleEffect.gameObject.SetActive(isActive);
    }

}
