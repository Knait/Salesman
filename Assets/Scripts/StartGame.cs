using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// ������ ����� �� ������ StartGame
/// </summary>
public class StartGame : MonoBehaviour, IPointerClickHandler
{
    public void OnStartGame()
    {
        GameController.Instance.StartGame();
        gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        OnStartGame();
    }
}


