
// Гавна скрипт висит на покупателе 
// чекает игрока
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHero : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }



    private void OnCollisionEnter(Collision collision)
    {
        CheckStand checkStand = collision.gameObject.GetComponent<CheckStand>();

        if (checkStand)
        {
            print("Hero");

        }
    }
}
