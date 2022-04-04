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
    /// ������� �������� ������� �������
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
    /// ������� ��������� ����� ������� � ����� ����������
    /// </summary>
    private void FindOpenPointBuy()
    {
        for (int index = 0; index < pointsBuy.Length; index++)
        {
            if (!pointsBuy[index].GetComponent<PointBuy>().pointActive)            ///������� ��� ��������� ����� �������
            {
                tempPointsBuy.Add(pointsBuy[index]);                                /// ������� � ������ ������ 
            }
        }

        // print("tempPointsBuy.Count " + tempPointsBuy.Count);

        if (tempPointsBuy.Count > 0)                                                  // ���� ������ �� ������
        {
            int i = Random.Range(0, tempPointsBuy.Count);                             /// �������� � ������ ������� �������� �����

            //print("Random Buy " + i);
            for (int j = 0; j < shoppers.Length; j++)                                // ���� ���� �����������
            {
                if (!shoppers[j].gameObject.activeInHierarchy)                         // ���� ���������� ����
                {
                    tempPointsBuy[i].GetComponent<PointBuy>().pointActive = true;        //��� ����� �������

                    shoppers[j].gameObject.SetActive(true);                               // ��� ����������

                    StateShopper stateShopper = shoppers[j].GetComponent<StateShopper>();

                    stateShopper.currentStartPosition = pointsSpawn[randomIndexPointsSpawn];           // ����� ����� ������

                    stateShopper.currentTarget = tempPointsBuy[i];                                      //����� ����� �������

                    tempPointsBuy.Clear();                                                        //������� ���� ������

                    stateShopper.stateBot = StateBot.Walk;                                     // ���������� ����� 

                    return;
                }
            }
        }
    }


    /// <summary>
    /// ������ ������ ����������
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
    /// ������� ����������
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
    /// ������ �������� �����������
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
    /// ������� ����������� � �������
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
