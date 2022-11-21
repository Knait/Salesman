using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// скрипт весит на панели StartGame
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


