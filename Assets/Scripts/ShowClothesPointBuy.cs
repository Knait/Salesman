using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowClothesPointBuy : MonoBehaviour
{
    [Header("Массив одежды")]
    [HideInInspector]
    public Transform[] arrayShowClothes;

    /// <summary>
    /// текущая шмотка на точке покупки
    /// </summary>
    private int currentIDClothes;

    void Start()
    {
        arrayShowClothes = new Transform[GameSettings.Instance.prefabShowClothes.Length + 1];
        Transform transPos = transform;
        for (int i = 0; i < GameSettings.Instance.prefabShowClothes.Length; i++)
        {
            arrayShowClothes[i + 1] = Instantiate(GameSettings.Instance.prefabShowClothes[i], transform.position, Quaternion.identity);
            arrayShowClothes[i + 1].localScale = new Vector3(0.3f, 0.3f, 0.3f);
            arrayShowClothes[i + 1].rotation = Quaternion.Euler(90, 0, 0);
            arrayShowClothes[i + 1].gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// вкл одежку и меняем цвет
    /// </summary>
    /// <param name="IDClothes"></param>
    /// <param name="currentIDMaterialBot"></param>
    public void SetActiveObject(int IDClothes, int currentIDMaterialBot)
    {
        arrayShowClothes[IDClothes].gameObject.SetActive(true);        ///вкл
        currentIDClothes = IDClothes;
        arrayShowClothes[IDClothes].GetComponent<SpriteRenderer>().material = GameSettings.Instance.arrayMaterial[currentIDMaterialBot];
        arrayShowClothes[IDClothes].GetChild(0).GetComponent<SpriteRenderer>().material = GameSettings.Instance.arrayMaterial[currentIDMaterialBot];
    }

    /// <summary>
    /// выкл одежку
    /// </summary>
    public void DeActiveObject()
    {
        arrayShowClothes[currentIDClothes].gameObject.SetActive(false);
    }
}
