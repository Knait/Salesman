using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PointShowCongratilation : MonoBehaviour
{
    [Header("Cсылка prefab")]
    [SerializeField]
    private Transform prefabUIShowCongratilation;

    [SerializeField]
    private Transform[] transformUIShowCongratilation;

    [SerializeField]
    private CongratilationUI[] congratilationUI;


    private TMP_Text[] textCongratulation;

    private string[] samlpeCongratulation = { "", "Best", "Excellent", "Good", "Badly" };

    private int i = 0;

    void Start()
    {
        int count = 2;
        transformUIShowCongratilation = new Transform[count];
        congratilationUI = new CongratilationUI[count];
        textCongratulation = new TMP_Text[count];



        for (i = 0; i < transformUIShowCongratilation.Length; i++)
        {
            transformUIShowCongratilation[i] = Instantiate(prefabUIShowCongratilation, Vector3.zero, Quaternion.identity);
            transformUIShowCongratilation[i].transform.SetParent(GameObject.Find("Canvas").transform);
            congratilationUI[i] = transformUIShowCongratilation[i].GetComponent<CongratilationUI>();
            congratilationUI[i].parentObject = gameObject.transform;
            textCongratulation[i] = transformUIShowCongratilation[i].GetComponent<TMP_Text>();
        }

        i = 0;
    }

    // Update is called once per frame
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

        congratilationUI[i].gameObject.SetActive(false);
        congratilationUI[i].gameObject.SetActive(true);
        textCongratulation[i].text = samlpeCongratulation[indexSamlpeCongratulation];

        i++;

        if (i == 2)
        {
            i = 0;
        }
    }




}
