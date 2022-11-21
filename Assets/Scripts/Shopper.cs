using UnityEngine;

public class Shopper : MonoBehaviour
{
    /// <summary>
    /// Текущий ID материал бота
    /// </summary>
    [HideInInspector]
    public int currentIDMaterialBot;
    /// <summary>
    /// Текущий ID одежды бота
    /// </summary>
    [HideInInspector]
    public int currentIDClothesBot;

    private void OnEnable()
    {
        currentIDMaterialBot = Random.Range(1, 5);
    }
}
