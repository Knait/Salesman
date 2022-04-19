using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShowCongratulation : MonoBehaviour
{
    //[SerializeField]
    //private float timerShowCongratulation;

    private string[] samlpeCongratulation = { "", "Best", "Excellent", "Good", "Badly" };

    [SerializeField]
    private TMP_Text[] textCongratulation;

    private int i = 0;

    void Start()
    {
        for (i = 0; i < textCongratulation.Length; i++)
        {
            textCongratulation[i].text = "";
        }

        i = 0;
    }


    public void ShowCongratulate(int currentMoneyForBuy)
    {
        int indexSamlpeCongratulation = 0;

        switch (currentMoneyForBuy)
        {
            case 10:
                indexSamlpeCongratulation = 1;
                break;

            case 7:
                indexSamlpeCongratulation = 2;
                break;

            case 3:
                indexSamlpeCongratulation = 3;
                break;

            case 0:
                indexSamlpeCongratulation = 4;
                break;
        }

        textCongratulation[i].gameObject.SetActive(false);
        textCongratulation[i].gameObject.SetActive(true);
        textCongratulation[i].text = samlpeCongratulation[indexSamlpeCongratulation];

        i++;

        if (i == 2)
        {
            i = 0;
        }
    }


}
