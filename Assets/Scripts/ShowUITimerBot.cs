using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUITimerBot : MonoBehaviour
{
    [SerializeField]
    private Transform prefabTimerUI;

    [SerializeField]
    private Transform transformTimerUI;

    [SerializeField]
    private TimerUIBot TimerUIBot;

    [SerializeField]
    private StateShopper stateShopper;

    //[HideInInspector]
    public float valueTimerUI;

    // Start is called before the first frame update
    void Start()
    {
        transformTimerUI = Instantiate(prefabTimerUI, Vector3.zero, Quaternion.identity);
        transformTimerUI.transform.SetParent(GameObject.Find("Canvas").transform);
        TimerUIBot = transformTimerUI.GetComponent<TimerUIBot>();
        TimerUIBot.parentObject = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        valueTimerUI = stateShopper.ÑalculationValueTimerUi();

        if (GameController.Instance.stateGame != StateGame.Game)
        {
            transformTimerUI.gameObject.SetActive(false);
        }
        else
        {
            transformTimerUI.gameObject.SetActive(true);
        }

    }
}
