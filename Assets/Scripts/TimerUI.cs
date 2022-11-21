using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    [HideInInspector]
    public Transform parentObject;
    private RectTransform rectTransform;
    [SerializeField]
    private PointUiShow pointUiShow;
    private Image imageTimerUI;
    
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        imageTimerUI = GetComponent<Image>();
        pointUiShow = parentObject.GetComponent<PointUiShow>();
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
        imageTimerUI.fillAmount = pointUiShow.valueTimerUI;
    }
}
