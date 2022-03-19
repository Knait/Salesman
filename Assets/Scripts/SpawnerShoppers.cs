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

    // Start is called before the first frame update
    void Start()
    {
        Shoppers = new Transform[10];
        for (int index = 0; index < Shoppers.Length; index++)
        {
            randomIndexPointsSpawn = Random.Range(0, PointsSpawn.Length);


            Shoppers[index] = Instantiate(prefabShopper, PointsSpawn[randomIndexPointsSpawn].position, Quaternion.identity);
            Shoppers[index].gameObject.SetActive(false);
        }

        currentDeltaComingClient = GameSettings.Instance.startDeltaComingClient;

        //for (int index = 0; index < PointsBuy.Length; index++)
        //{
        //    PointsBuy[index].gameObject.SetActive(false);
        //}

        //currentDeltaComingClient = 1;

        StartCoroutine(TimerSpawnShopper(currentDeltaComingClient));
    }

    // Update is called once per frame
    void Update()
    {

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
                        //PointsBuy[i].gameObject.SetActive(true);

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

}
