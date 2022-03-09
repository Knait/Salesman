using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance;

    [Header("Начальная скорость игрока")]
    public  float speedBegin;

    [Header("Значение Upgrade скорости прокачки")]
    public  float multiPlay;

    [Header("Мах кол-во одежды у игрока")]
    public int maxCountClothes;


    private void Awake()
    {
        Instance = this;
    }


}
