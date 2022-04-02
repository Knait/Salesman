using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerShoppers : MonoBehaviour
{
    public Transform[] PointsBuy;

    public Transform[] Shoppers;

    public Transform[] PointsSpawn;

    [SerializeField]
    private Transform prefabShopper;

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

    private void FindOpenPointBuy()
    {
        for (int i = 0; i < PointsBuy.Length; i++)
        {
            if (!PointsBuy[i].GetComponent<PointBuy>().pointActive)
            {
                for (int j = 0; j < Shoppers.Length; j++)
                {
                    if (!Shoppers[j].gameObject.activeInHierarchy)
                    {
                        PointsBuy[i].GetComponent<PointBuy>().pointActive = true;        //вкл точку покупки

                        Shoppers[j].gameObject.SetActive(true);

                        StateShopper stateShopper = Shoppers[j].GetComponent<StateShopper>();

                        stateShopper.currentStartPosition = PointsSpawn[randomIndexPointsSpawn];

                        stateShopper.currentTarget = PointsBuy[i];

                        stateShopper.stateBot = StateBot.Walk;

                        return;
                    }
                }

            }

        }
    }


    private IEnumerator TimerSpawnShopper(float timerSpawnShopper)
    {
        while (true)
        {
            FindOpenPointBuy();

            yield return new WaitForSeconds(timerSpawnShopper);
        }


    }


    private int InstantiateBot(int IDClothes, int j)
    {
        randomIndexPointsSpawn = Random.Range(0, PointsSpawn.Length);

        Shoppers[j] = Instantiate(prefabShopper, PointsSpawn[randomIndexPointsSpawn].position, Quaternion.identity);
        Shoppers[j].GetComponent<Shopper>().currentIDClothesBot = IDClothes;
        Shoppers[j].gameObject.SetActive(false);

        j++;
        return j;
    }


    private void InstantiateShoppers()
    {
        int countShoppers = 8;

        Shoppers = new Transform[countShoppers];

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


    private void BlendShoppers()
    {
        for (int i = Shoppers.Length - 1; i >= 1; i--)
        {
            int j = Random.Range(0, i + 1);

            Transform temp = Shoppers[j];
            Shoppers[j] = Shoppers[i];
            Shoppers[i] = temp;

        }
    }
}
