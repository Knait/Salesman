using UnityEngine;

public class DeleteDataPrefs : MonoBehaviour
{
    void Start()
    {
        Debug.Log(" Delete all data");
        PlayerPrefs.DeleteAll();
    }
}
