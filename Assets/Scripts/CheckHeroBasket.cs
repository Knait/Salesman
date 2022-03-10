using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHeroBasket : CheckHero
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void MyMethod(HeroController heroController)
    {
        print("Basket  Hero");

        heroController.CheckDoubleInArray();
    }
}
