using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShowCongratulation : MonoBehaviour
{
    [SerializeField]
    private float timerShowCongratulation;

    private string[] samlpeCongratulation = { "","Best", "Excellent", "Good", "Badly" };

    [SerializeField]
    private TMP_Text textCongratulation;

    
    void Start()
    {
        textCongratulation = GetComponent<TMP_Text>();
        textCongratulation.text = "";

    }


    public IEnumerator ShowCongratulate(int currentMoneyForBuy)
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


        textCongratulation.text = samlpeCongratulation[indexSamlpeCongratulation];

        yield return new WaitForSeconds(timerShowCongratulation);
        textCongratulation.text = samlpeCongratulation[0];
        gameObject.SetActive(false);

    }


}
