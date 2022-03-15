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

    // Start is called before the first frame update
    void Start()
    {
        Shoppers = new Transform[10];
        for (int index = 0; index < Shoppers.Length; index++)
        {
            Shoppers[index] = Instantiate(prefabShopper, new Vector3(0, 0, 0), Quaternion.identity);
            Shoppers[index].gameObject.SetActive(false);
        }

        currentDeltaComingClient = GameSettings.Instance.startDeltaComingClient;

        for (int index = 0; index < PointsBuy.Length; index++)
        {
            PointsBuy[index].gameObject.SetActive(false);
        }

        //currentDeltaComingClient = 1;

        StartCoroutine(TimerSpawnShopper(currentDeltaComingClient));
    }

    // Update is called once per frame
    void Update()
    {

    }


    private IEnumerator TimerSpawnShopper(float timerSpawnShopper)
    {
        while (true)
        {
            for (int i = 0; i < PointsBuy.Length; i++)
            {
                if (!PointsBuy[i].gameObject.activeInHierarchy)
                {
                    for (int j = 0; j < Shoppers.Length; j++)
                    {
                        if (!Shoppers[j].gameObject.activeInHierarchy)
                        {
                            PointsBuy[i].gameObject.SetActive(true);

                            Shoppers[j].gameObject.SetActive(true);

                            int randomIndexPointsSpawn = Random.Range(0, PointsSpawn.Length);

                            //Shoppers[j].position = PointsSpawn[randomIndexPointsSpawn].position;

                            StateShopper stateShopper = Shoppers[j].GetComponent<StateShopper>();

                            stateShopper.currentStartPosition = PointsSpawn[randomIndexPointsSpawn];
                            stateShopper.currentTarget = PointsBuy[i];
                            stateShopper.stateBot = StateBot.Walk;
                            break;
                        }
                    }

                    break;
                }

            }

            yield return new WaitForSeconds(timerSpawnShopper);
        }


    }

}
