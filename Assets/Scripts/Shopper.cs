using UnityEngine;

public class Shopper : MonoBehaviour
{
    /// <summary>
    /// ������� ID �������� ����
    /// </summary>
    [HideInInspector]
    public int currentIDMaterialBot;
    /// <summary>
    /// ������� ID ������ ����
    /// </summary>
    [HideInInspector]
    public int currentIDClothesBot;

    private void OnEnable()
    {
        currentIDMaterialBot = Random.Range(1, 5);
    }
}
