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
            IsHero(heroController);
        }
    }

    protected void OnTriggerEnter(Collider other)
    {
        HeroController heroController = other.gameObject.GetComponent<HeroController>();

        if (heroController)
        {
            IsHero(heroController);
        }
    }



    protected abstract void IsHero(HeroController heroController);

}
