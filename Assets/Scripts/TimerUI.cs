
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerUI : MonoBehaviour
{
    //[HideInInspector]
    public Transform parentObject;

    private RectTransform rectTransform;

    private Image imageTimerUI;

    [SerializeField]
    private PointUiShow pointUiShow;
    

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        imageTimerUI = GetComponent<Image>();
        pointUiShow = parentObject.GetComponent<PointUiShow>();
        imageTimerUI.fillAmount = 0;
    }

    // Update is called once per frame
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
        imageTimerUI.fillAmount = pointUiShow.valueTimerUI;
    }
}
