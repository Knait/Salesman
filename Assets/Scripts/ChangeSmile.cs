using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// висит на точке продаж
/// </summary>
public class ChangeSmile : MonoBehaviour
{
    [Header("Массив смайлики")]
    [SerializeField]
    private Sprite[] sprites;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ShowSmile(int currentMoneyForBuy, Transform parentObject)
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x = parentObject.position.x;
        currentPosition.z = parentObject.position.z;
        gameObject.transform.position = currentPosition;
        int indexSamlpeCongratulation = 0;
        switch (currentMoneyForBuy)
        {
            case 10:
                indexSamlpeCongratulation = 0;
                break;

            case 7:
                indexSamlpeCongratulation = 1;
                break;

            case 3:
                indexSamlpeCongratulation = 2;
                break;

            case 0:
                indexSamlpeCongratulation = 3;
                break;

            case -2:
                indexSamlpeCongratulation = 4;
                break;
        }

        spriteRenderer.sprite = sprites[indexSamlpeCongratulation];
    }
}
