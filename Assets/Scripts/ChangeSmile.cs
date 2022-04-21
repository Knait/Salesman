
/// висит на точке продаж

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSmile : MonoBehaviour
{
    [SerializeField]
    private Transform prefabUISmile;

    [SerializeField]
    private Transform transformUISmile;

    [SerializeField]
    private Smile smile;

    [Header("Массив смайлики")]
    [SerializeField]
    private Sprite[] sprites;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        transformUISmile = Instantiate(prefabUISmile, Vector3.zero, Quaternion.identity);
        transformUISmile.transform.SetParent(GameObject.Find("Canvas").transform);
        smile = transformUISmile.GetComponent<Smile>();
        smile.parentObject = gameObject.transform;
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


        transformUISmile.gameObject.SetActive(false);   // запускаем 
        transformUISmile.gameObject.SetActive(true);      //   спрайт 
        smile.imageSmileUI.sprite = sprites[indexSamlpeCongratulation];
    }
}

