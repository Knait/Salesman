using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointUiShow : MonoBehaviour
{

    [SerializeField]
    private Transform prefabTimerUI;

    [SerializeField]
    private Transform transformTimerUI;

    [SerializeField]
    private TimerUI timerUI;

    [SerializeField]
    private HeroController heroController;

    //[HideInInspector]
    public float valueTimerUI;

    // Start is called before the first frame update
    void Start()
    {
        transformTimerUI = Instantiate(prefabTimerUI, Vector3.zero, Quaternion.identity);
        transformTimerUI.transform.SetParent(GameObject.Find("Canvas").transform);
        timerUI = transformTimerUI.GetComponent<TimerUI>();
        timerUI.parentObject = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        valueTimerUI = heroController.�alculationValueTimerUi();
    }
}