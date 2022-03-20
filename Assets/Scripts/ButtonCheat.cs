using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCheat : MonoBehaviour
{
    private int countPush;
   
    public void Cheat()
    {
        countPush++;

        if (countPush == 10) GameController.Instance.currentMoney = 10000;
    }
}
