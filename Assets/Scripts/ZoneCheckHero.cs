//говно скрипт висит на зоне чека игрока дл€ подсветки

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneCheckHero : MonoBehaviour
{


    [SerializeField]
    private Material defaultMaterial;

    //[HideInInspector]
    public int currentIDMaterialBot;

    [SerializeField]
    private Material currentMaterialBot;

    [SerializeField]
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        defaultMaterial = _renderer.material;
    }

    private void Update()
    {
        //if (currentIDMaterialBot == 0)
        // {
        //currentIDMaterialBot = setRandomMaterial.IDMaterialClothes;
        //currentMaterialBot = GameSettings.Instance.arrayMaterial[currentIDMaterialBot];
        //currentColorBot = currentMaterialBot.color;
        // currentLight.color = currentColorBot;

        // }

    }

    private void OnTriggerEnter(Collider other)
    {
        HeroController heroController = other.gameObject.GetComponent<HeroController>();

        if (heroController)
        {
            if (currentIDMaterialBot != 0)
            {
                if (heroController.CompareClothes(currentIDMaterialBot, 1) != 0)
                {
                   // print(" hero In zone ");                   ////////////////////////////////////////
                    //SetMaterialObject(GameSettings.Instance.arrayMaterial[currentIDMaterialBot]);
                }
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        HeroController heroController = other.gameObject.GetComponent<HeroController>();

        if (heroController)
        {
            SetMaterialObject();
            //print("Hero out zone");             /////////////////////////////////////////
        }
    }

    /// <summary>
    /// ¬кл выкл подсветки «оны
    /// </summary>
    /// <param name="stateObj"></param>
    public void SetMaterialObject(Material materialObj)
    {
        _renderer.material = materialObj;
    }

    /// <summary>
    /// ¬кл выкл подсветки «оны
    /// </summary>
    /// <param name="stateObj"></param>
    public void SetMaterialObject()
    {
        _renderer.material = defaultMaterial;
    }
}
