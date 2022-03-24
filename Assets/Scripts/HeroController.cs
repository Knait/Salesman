// говноСкрипт висит на игроке
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HeroController : MonoBehaviour
{
    /// <summary>
    /// Колво за правильную одежку
    /// </summary>
    [SerializeField]
    private int countMoneyClothes;

    /// <summary>
    /// Колво за правильный цвет
    /// </summary>
    [SerializeField]
    private int countMoneyColor;

    [Header("Ссылка на одежу в руках")]
    [SerializeField]
    private Transform[] clothesInHands;

    [Header("Мах кол-во одежды")]
    [SerializeField]
    private int maxCountClothes;

    /// <summary>
    /// Дефолтный материал белая одежда
    /// </summary>
    [SerializeField]
    private Material defaultMaterial;


    //[SerializeField]
    public Clothes[] arrayClothes;       // массив классов одежды у игрока на руках

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

    void Start()
    {
        maxCountClothes = GameSettings.Instance.maxCountClothes;

        arrayClothes = new Clothes[maxCountClothes];
        for (int index = 0; index < arrayClothes.Length; index++)
        {
            arrayClothes[index] = new Clothes();
        }

        defaultMaterial = clothesInHands[0].GetComponent<MeshRenderer>().material;
        ShowСlothesInHands();
    }

    /// <summary>
    /// Берет одежку
    /// </summary>
    /// <param name="materialClothes"></param>
    public void TakeClothes(int IDClothes)
    {
        for (int index = 0; index < arrayClothes.Length; index++)
        {
            if (arrayClothes[index].IDClothes == 0)
            {
                arrayClothes[index].IDClothes = IDClothes;

                ShowСlothesInHands();

                break;
            }
        }
    }



    /// <summary>
    /// Красим одежку
    /// </summary>
    /// <param name="IDMaterialClothes"></param>
    public void PaintingClothes(int IDMaterialClothes)
    {
        for (int index = 0; index < arrayClothes.Length; index++)
        {
            if (arrayClothes[index].IDClothes != 0)
            {
                arrayClothes[index].IDMaterialClothes = IDMaterialClothes;
            }
        }

        ShowСlothesInHands();
    }





    /// <summary>
    /// Проверяем одежку на двойников если есть удаляем
    /// </summary>
    public bool CheckDoubleInArray()
    {
        bool result = false;

        //for (int i = 1; i < arrayIDMaterialClothes.Length; i++)
        //{
        //    if (arrayIDMaterialClothes[i] > 0)
        //    {
        //        RemoveClothes(i);
        //        result = true;
        //        break;
        //    }
        //    else
        //    {
        //        continue;
        //    }
        //}

        return result;
    }


    /// <summary>
    /// удаление одежды у игрока
    /// </summary>
    /// <param name="arrayMaterialClothes"></param>
    /// <param name="index"></param>
    public void RemoveClothes(int index)
    {
        //print("Remove Clothes");                  /////////////////////////////////////////////////////
        // arrayIDMaterialClothes[index] = 0;

        arrayClothes[index].IDClothes = 0;
        arrayClothes[index].IDMaterialClothes = 0;

        ShowСlothesInHands();
    }


    /// <summary>
    /// Сравниваем одекжу Бота и у игрока
    /// </summary>
    /// <param name="clothesBot"></param>
    public int CompareClothes(int currentIDClothesBot, int currentIDMaterialBot)
    {
        int result = 0;

        for (int index = 0; index < arrayClothes.Length; index++)
        {
            if (currentIDClothesBot == arrayClothes[index].IDClothes)
            {
                result += countMoneyClothes;
            }

            if (currentIDMaterialBot == arrayClothes[index].IDMaterialClothes)
            {
                result += countMoneyColor;
            }

            if (result > 0)
            {
                RemoveClothes(index);
                break;
            }
        }

        return result;
    }

    //public void ShowСlothesInHands(int iDMaterialClothes)
    //{
    //    clothesInHands[].GetComponent<MeshRenderer>().material = GameSettings.Instance.arrayMaterial[iDMaterialClothes];
    //}




    /// <summary>
    /// Показываем одежку в руках и красим
    /// </summary>
    public void ShowСlothesInHands()
    {
        for (int index = 0; index < arrayClothes.Length; index++)
        {
            if (arrayClothes[index].IDClothes != 0)
            {
                clothesInHands[index].gameObject.SetActive(true);

                if (arrayClothes[index].IDMaterialClothes != 0)
                {
                    clothesInHands[index].GetComponent<MeshRenderer>().material = GameSettings.Instance.arrayMaterial[arrayClothes[index].IDMaterialClothes];
                }
                else
                {
                    clothesInHands[index].GetComponent<MeshRenderer>().material = defaultMaterial;
                }
            }
            else
            {
                
                clothesInHands[index].gameObject.SetActive(false);
            }

        }
    }

    [System.Serializable]
    public class Clothes
    {
        public int IDClothes;
        public int IDMaterialClothes;
    }


}
