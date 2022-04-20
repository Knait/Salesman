using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratilationUI : MonoBehaviour
{
    //[HideInInspector]
    public Transform parentObject;

    private RectTransform rectTransform;


    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
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
