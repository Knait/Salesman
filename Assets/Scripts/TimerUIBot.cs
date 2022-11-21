using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerUIBot : MonoBehaviour
{
    [HideInInspector]
    public Transform parentObject;
    private RectTransform rectTransform;
    [SerializeField]
    private Image imageTimerUI;
    [SerializeField]
    private Image backGround;
    [SerializeField]
    private ShowUITimerBot showUITimerBot;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        showUITimerBot = parentObject.GetComponent<ShowUITimerBot>();
        imageTimerUI.fillAmount = 0;
    }

    void Update()
    {
        UpdateShowTimer();
        UpdateValueTimerUi();

    }

    private void UpdateShowTimer()
    {
        Vector3 parentObjectPosition = new Vector3(parentObject.position.x, parentObject.position.y, parentObject.position.z);
        rectTransform.position = Camera.main.WorldToScreenPoint(parentObjectPosition);
    }

    private void UpdateValueTimerUi()
    {
        if (showUITimerBot.valueTimerUI == 0)
        {
            backGround.gameObject.SetActive(false);
        }
        else
        {
            backGround.gameObject.SetActive(true);
        }

        imageTimerUI.fillAmount = showUITimerBot.valueTimerUI;
    }
}
