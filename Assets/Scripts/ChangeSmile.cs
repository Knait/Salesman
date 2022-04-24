
/// ����� �� ����� ������

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

    //[SerializeField]
    //private Transform parentObject;

    [Header("������ ��������")]
    [SerializeField]
    private Sprite[] sprites;

    //private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        transformUISmile = Instantiate(prefabUISmile, Vector3.zero, Quaternion.identity);
        //transformUISmile.transform.SetParent(GameObject.Find("Canvas").transform);
        //smile = transformUISmile.GetComponent<Smile>();
        smile = transformUISmile.GetComponentInChildren<Smile>();
        //smile.parentObject = gameObject.transform;
    }

    public void ShowSmile(int currentMoneyForBuy, Transform parentObject)
    {

        Vector3 currentPosition = parentObject.position;

        gameObject.transform.position = currentPosition;

        Vector3 parentObjectPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        smile.rectTransform.position = Camera.main.WorldToScreenPoint(parentObjectPosition);

        smile.parentObject = transform;

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


        transformUISmile.gameObject.SetActive(false);   // ��������� 
        transformUISmile.gameObject.SetActive(true);      //   ������ 
        //Debug.LogError("Ha");
        smile.imageSmileUI.sprite = sprites[indexSamlpeCongratulation];
    }
}

