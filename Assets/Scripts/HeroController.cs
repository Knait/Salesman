// говноСкрипт висит на игроке
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HeroController : MonoBehaviour
{
    /// <summary>
    /// Колво денех за правильную одежку
    /// </summary>
    [SerializeField]
    private int countMoneyClothes;

    /// <summary>
    /// Колво денех за правильный цвет
    /// </summary>
    [SerializeField]
    private int countMoneyColor;

    /// <summary>
    /// Ссылка поздравления на игроке
    /// </summary>
    [Header("ShowCongratulation на игроке")]
    [SerializeField]
    private ShowCongratulation showCongratulation;

    /// <summary>
    /// Массив ссылка на одежу в руках
    /// </summary>
    [Header("Массив ссылка на одежу в руках")]
    [SerializeField]
    private Transform[] clothesInHands;

    /// <summary>
    /// Мах кол-во одежды
    /// </summary>
    [Header("Мах кол-во одежды")]
    [SerializeField]
    private int maxCountClothes;

    /// <summary>
    /// Дефолтный материал белая одежда
    /// </summary>
    [SerializeField]
    private Material defaultMaterial;

    /// <summary>
    /// массив классов одежды у игрока на руках
    /// </summary>
    //[SerializeField]
    public Clothes[] arrayClothes;

    /// <summary>
    /// Колво одежи в руках
    /// </summary>
    [SerializeField]
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

    //[SerializeField]
    //int[] resultTemp;

    [SerializeField]
    private MoveController moveController;

    void Start()
    {
        moveController = GetComponent<MoveController>();

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
                countClothes++;

                ShowСlothesInHands();

                break;
            }
        }
    }



    /// <summary>
    /// Красим одежку
    /// </summary>
    /// <param name="IDMaterialClothes"></param>
    public bool PaintingClothes(int IDMaterialClothes)
    {
        bool result = false;

        for (int index = 0; index < arrayClothes.Length; index++)
        {
            if (arrayClothes[index].IDClothes != 0)
            {
                arrayClothes[index].IDMaterialClothes = IDMaterialClothes;
                result = true;
            }
        }

        ShowСlothesInHands();

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

        arrayClothes[index].IDClothes = 0;
        arrayClothes[index].IDMaterialClothes = 0;
        countClothes--;

        ShowСlothesInHands();
    }


    /// <summary>
    /// Сравниваем одекжу Бота и игрока
    /// </summary>
    /// <param name="clothesBot"></param>
    public int CompareClothes(int currentIDClothesBot, int currentIDMaterialBot, out int currentBuyIDMaterialClothes)
    {
        currentBuyIDMaterialClothes = 0;

        int indexArrayClothes = 0;

        int result = 0;

        int[] resultTemp = new int[2];

        if (countClothes > 0)
        {
            for (int index = 0; index < arrayClothes.Length; index++)
            {
                if (currentIDClothesBot == arrayClothes[index].IDClothes)
                {
                    resultTemp[index] += countMoneyClothes;

                }
                if (currentIDMaterialBot == arrayClothes[index].IDMaterialClothes)
                {
                    resultTemp[index] += countMoneyColor;
                }
            }

            if (resultTemp[0] > resultTemp[1])
            {
                result = resultTemp[0];
                indexArrayClothes = 0;
            }
            else if (arrayClothes[0].IDClothes != 0)
            {
                result = resultTemp[0];
                indexArrayClothes = 0;
            }
            else
            {
                result = resultTemp[1];
                indexArrayClothes = 1;
            }

            //   print(" index " + indexArrayClothes);
            currentBuyIDMaterialClothes = arrayClothes[indexArrayClothes].IDMaterialClothes;       //сетим ID материал проданной шмотки

            RemoveClothes(indexArrayClothes);                                               // удаляем из массива одежды игрока одежду которую отдали
        }
        else
        {
            result = -1;                    // ничего не продали
        }

        StartCoroutine(showCongratulation.ShowCongratulate(result));
        return result;
    }






    /// <summary>
    /// Показываем одежку в руках и красим
    /// </summary>
    public void ShowСlothesInHands()
    {

        moveController.SetAnimatorWithBox(countClothes > 0);                  // сетим состояние аниматора с коробкой

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

    /// <summary>
    /// Расчет Значения для таймера UI
    /// </summary>
    /// <returns></returns>
    public float СalculationValueTimerUi()
    {
        float result = 0;

        result = (float)countClothes / maxCountClothes;
        return result;
    }

    /// <summary>
    /// Класс одежда
    /// </summary>
    [System.Serializable]
    public class Clothes
    {
        /// <summary>
        /// ID Одежды
        /// </summary>
        public int IDClothes;

        /// <summary>
        /// ID Материалов одежды 
        /// </summary>
        public int IDMaterialClothes;
    }


}
