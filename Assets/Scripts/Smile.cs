using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Smile : MonoBehaviour
{
    public Transform parentObject;

    private RectTransform rectTransform;
    
    public Image imageSmileUI;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        imageSmileUI = GetComponent<Image>();

        Vector3 parentObjectPosition = new Vector3(parentObject.position.x, parentObject.position.y, parentObject.position.z);
        rectTransform.position = Camera.main.WorldToScreenPoint(parentObjectPosition);
        gameObject.SetActive(false);   
    }
}
