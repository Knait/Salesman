
/// висит на точке продаж

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSmile : MonoBehaviour
{
    [Header("Массив смайлики")]
    [SerializeField]
    private Sprite[] sprites;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ShowSmile(int currentMoneyForBuy)
    {
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
        }
        spriteRenderer.sprite = sprites[indexSamlpeCongratulation];
    }
}

