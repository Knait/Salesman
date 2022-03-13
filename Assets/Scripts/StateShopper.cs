using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum StateBot
{
    Start,
    Walk,
    Buy,
    Exit
}

public class StateShopper : MonoBehaviour
{
    [SerializeField]
    private StateBot stateBot;

    [SerializeField]
    private ShopperController shopperController;

    //[HideInInspector]
    public Transform currentTarget;   // текущая цель


    // Start is called before the first frame update
    void Start()
    {
        shopperController = GetComponent<ShopperController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStateShopper();
    }

    private void UpdateStateShopper()
    {
        switch(stateBot)
        {
            case StateBot.Start:

                break;

            case StateBot.Walk:

                break;

            case StateBot.Buy:

                break;

            case StateBot.Exit:

                break;
        }




    }

}
