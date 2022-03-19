using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



/// <summary>
/// ������ ����� �� ������ NEXT 
/// </summary>
public class NextLevel : MonoBehaviour
{
    public void LoadScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;   // ������� �����
        SceneManager.LoadScene(currentScene);            // ����� �������
    }
}
