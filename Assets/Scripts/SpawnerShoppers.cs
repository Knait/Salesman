using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerShoppers : MonoBehaviour
{
    public Transform[] pointsBuy;

    public Transform[] shoppers;

    public Transform[] pointsSpawn;

    [SerializeField]
    private Transform prefabShopper;

    [SerializeField]
    List<Transform> tempPointsBuy;

    /// <summary>
    /// Текущий интервал прихода клиента
    /// </summary>
    [SerializeField]
    private float currentDeltaComingClient;

    private int randomIndexPointsSpawn;

    void Start()
    {
        InstantiateShoppers();

        currentDeltaComingClient = GameSettings.Instance.startDeltaComingClient;

        StartCoroutine(TimerSpawnShopper(currentDeltaComingClient));
    }


    /// <summary>
    /// Находим свободную точку покупки и сетим покупателя
    /// </summary>
    private void FindOpenPointBuy()
    {
        for (int index = 0; index < pointsBuy.Length; index++)
        {
            if (!pointsBuy[index].GetComponent<PointBuy>().pointActive)            ///Находим все свободные точки покупки
            {
                tempPointsBuy.Add(pointsBuy[index]);                                /// заносим в промеж массив 
            }
        }

        // print("tempPointsBuy.Count " + tempPointsBuy.Count);

        if (tempPointsBuy.Count > 0)                                                  // если массив не пустой
        {
            int i = Random.Range(0, tempPointsBuy.Count);                             /// выбираем в промеж массиве рандомно точку

            //print("Random Buy " + i);
            for (int j = 0; j < shoppers.Length; j++)                                // ищем выкл покупателей
            {
                if (!shoppers[j].gameObject.activeInHierarchy)                         // если покупатель выкл
                {
                    tempPointsBuy[i].GetComponent<PointBuy>().pointActive = true;        //вкл точку покупки

                    shoppers[j].gameObject.SetActive(true);                               // вкл покупателя

                    StateShopper stateShopper = shoppers[j].GetComponent<StateShopper>();

                    stateShopper.currentStartPosition = pointsSpawn[randomIndexPointsSpawn];           // сетим точку спавна

                    stateShopper.currentTarget = tempPointsBuy[i];                                      //сетим точку покупки

                    tempPointsBuy.Clear();                                                        //очищаем врем массив

                    stateShopper.stateBot = StateBot.Walk;                                     // покупатель бежит 

                    return;
                }
            }
        }
    }


    /// <summary>
    /// таймер спавна покупателя
    /// </summary>
    /// <param name="timerSpawnShopper"></param>
    /// <returns></returns>
    private IEnumerator TimerSpawnShopper(float timerSpawnShopper)
    {
        while (true)
        {
            FindOpenPointBuy();

            yield return new WaitForSeconds(timerSpawnShopper);
        }


    }


    /// <summary>
    /// создаем покупателя
    /// </summary>
    /// <param name="IDClothes"></param>
    /// <param name="j"></param>
    /// <returns></returns>
    private int InstantiateBot(int IDClothes, int j)
    {
        randomIndexPointsSpawn = Random.Range(0, pointsSpawn.Length);

        shoppers[j] = Instantiate(prefabShopper, pointsSpawn[randomIndexPointsSpawn].position, Quaternion.identity);
        shoppers[j].GetComponent<Shopper>().currentIDClothesBot = IDClothes;
        shoppers[j].gameObject.SetActive(false);

        j++;
        return j;
    }



    /// <summary>
    /// логика создания покупателей
    /// </summary>
    private void InstantiateShoppers()
    {
        int countShoppers = 8;

        shoppers = new Transform[countShoppers];

        int[] arrayIDClothes;

        arrayIDClothes = GameSettings.Instance.arrayIDClothes;

        int j = 0;

        for (int IDClothes = 0; IDClothes < arrayIDClothes.Length; IDClothes++)
        {
            j = InstantiateBot(arrayIDClothes[IDClothes], j);
            j = InstantiateBot(arrayIDClothes[IDClothes], j);
        }

        BlendShoppers();
    }

    /// <summary>
    /// перемес покупателей в массиве
    /// </summary>
    private void BlendShoppers()
    {
        for (int i = shoppers.Length - 1; i >= 1; i--)
        {
            int j = Random.Range(0, i + 1);

            Transform temp = shoppers[j];
            shoppers[j] = shoppers[i];
            shoppers[i] = temp;

        }
    }
}
