using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowClothesPointBuy : MonoBehaviour
{
    [SerializeField]
    private Transform[] prefabShowClothes;

    [HideInInspector]
    public Transform[] arrayShowClothes;

    private int currentIDClothes;

    void Start()
    {
        arrayShowClothes = new Transform[prefabShowClothes.Length + 1];

        Transform transPos = transform;

        for (int i = 0; i < prefabShowClothes.Length; i++)
        {
            arrayShowClothes[i + 1] = Instantiate(prefabShowClothes[i], transform.position, Quaternion.identity);
            arrayShowClothes[i + 1].localScale = new Vector3(0.3f, 0.3f, 0.3f);
            arrayShowClothes[i + 1].rotation = Quaternion.Euler(90, 0, 0);
            arrayShowClothes[i + 1].gameObject.SetActive(false);
        }
    }

    void Update()
    {

    
    }

    public void SetActiveObject(int IDClothes)
    {
        arrayShowClothes[IDClothes].gameObject.SetActive(true);

        currentIDClothes = IDClothes;
    }

    public void DeActiveObject()
    {
        arrayShowClothes[currentIDClothes].gameObject.SetActive(false);

    }


}
