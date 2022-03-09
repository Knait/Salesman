// говно—крипт висит на игроке
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStand : MonoBehaviour
{
    [Header("—сылка на одежу в руках")]
    [SerializeField]
    private Transform clothesInHands;

    [Header("ћах кол-во одежды")]
    private int maxCountClothes;

    private int countClothes;
    public int CountClothes
    {
        get
        {
            return countClothes;
        }

        set
        {
            if (value <= maxCountClothes)  // если выходим за пределы
            {
                countClothes = value;
            }
            else
            {
                countClothes = maxCountClothes;  // то кол-во равно мах значению
            }
        }
    }

    private Material[] arrayMaterialClothes;

    void Start()
    {
        maxCountClothes = GameSettings.Instance.maxCountClothes;
        arrayMaterialClothes = new Material[maxCountClothes];
    }

    void Update()
    {

    }

    public void TakeClothes(Material materialClothes)
    {
        for(int index = 0; index < arrayMaterialClothes.Length; index++)
        {
            if (!arrayMaterialClothes[index])
            {
                arrayMaterialClothes[index] = materialClothes;
                clothesInHands.GetComponent<Renderer>().material = materialClothes;

                break;
            }

        }
    }

}
