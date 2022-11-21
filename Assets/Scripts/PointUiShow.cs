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

    [HideInInspector]
    public float valueTimerUI;

    void Start()
    {
        transformTimerUI = Instantiate(prefabTimerUI, Vector3.zero, Quaternion.identity);
        transformTimerUI.transform.SetParent(GameObject.Find("Canvas").transform);
        timerUI = transformTimerUI.GetComponent<TimerUI>();
        timerUI.parentObject = gameObject.transform;
    }

    void Update()
    {
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
