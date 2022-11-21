using UnityEngine;

public class CongratilationUI : MonoBehaviour
{
    public Transform parentObject;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        UpdateShowTimer();
    }

    private void UpdateShowTimer()
    {
        Vector3 parentObjectPosition = new Vector3(parentObject.position.x, parentObject.position.y, parentObject.position.z);
        rectTransform.position = Camera.main.WorldToScreenPoint(parentObjectPosition);
    }

}
