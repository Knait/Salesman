//говно скрипт висит на зоне чека игрока для подсветки

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneCheckHero : MonoBehaviour
{
    [Header("Ссылка на подсветку Бота")]
    [SerializeField]
    private Transform zoneSpotLight;

    [SerializeField]
    private int currentIDMaterialBot;

    [SerializeField]
    private SetRandomMaterial setRandomMaterial;

    [SerializeField]
    private Material currentMaterialBot;

    [SerializeField]
    private Color currentColorBot;

    [SerializeField]
    private Light currentLight;




    private void Start()
    {
        setRandomMaterial = GetComponentInParent<SetRandomMaterial>();

        currentLight = zoneSpotLight.GetComponent<Light>();

    }

    private void Update()
    {
        if (currentIDMaterialBot == 0)
        {
            currentIDMaterialBot = setRandomMaterial.IDMaterialClothes;
            currentMaterialBot = GameSettings.Instance.arrayMaterial[currentIDMaterialBot];
            currentColorBot = currentMaterialBot.color;
            currentLight.color = currentColorBot;

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        HeroController heroController = other.gameObject.GetComponent<HeroController>();

        if (heroController)
        {
            if (heroController.CompareClothes(currentIDMaterialBot) != 0)
            {
                SetStateObject(true);
                print(" hero In zone ");

            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        HeroController heroController = other.gameObject.GetComponent<HeroController>();

        if (heroController)
        {
            SetStateObject(false);

            print("Hero out zone");
        }
    }

    /// <summary>
    /// Вкл выкл подсветки
    /// </summary>
    /// <param name="stateObj"></param>
    public void SetStateObject(bool stateObj)
    {

        zoneSpotLight.gameObject.SetActive(stateObj);
    }

}
