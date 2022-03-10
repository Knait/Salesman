// Гавна скрипт висит на покупателе 
// чекает игрока
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CheckHero : MonoBehaviour
{
   
    protected  void OnCollisionEnter(Collision collision)
    {
        HeroController heroController = collision.gameObject.GetComponent<HeroController>();

        if (heroController)
        {
            //print("Hero");
            MyMethod(heroController);
        }
    }

    protected abstract void MyMethod(HeroController heroController);

}
