using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonCheat : MonoBehaviour, IPointerClickHandler
{
    private int countPush;

    public void OnPointerClick(PointerEventData eventData)
    {
        countPush++;

        if (countPush == 10) GameController.Instance.currentMoney = 10000;
        print(" ha " + countPush);
    }

}
