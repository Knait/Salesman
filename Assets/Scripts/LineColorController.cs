using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineColorController : MonoBehaviour
{

    [SerializeField]

    private int IDMaterialClothes;

    void Start()
    {

    }

    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        HeroController heroController = other.gameObject.GetComponent<HeroController>();

        if (heroController)
        {
                print(" Color Clothes");  /////////////////////////////////////////////////////
                heroController.PaintingClothes(IDMaterialClothes);
        }
    }

}
