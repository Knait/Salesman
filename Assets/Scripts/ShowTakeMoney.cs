using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ShowTakeMoney : MonoBehaviour
{
    [Header(" Скорость перемещения UI")]
    [SerializeField]
    private float speed;

    [SerializeField]
    private float timer;

    //[HideInInspector]
    public int countTakeMoney;

    private TMP_Text textMeshShowTakeMoney;

    private bool isTimer;


    private void Start()
    {
        textMeshShowTakeMoney = GetComponent<TMP_Text>();
        countTakeMoney = GameSettings.Instance.countMoneyRemove;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTimer)
        {
            StartCoroutine(TimerLifeObject(timer));
        }

        float yMovement = 1.0f;

        Vector3 movement = new Vector3(0, yMovement, 0) * speed;

        transform.Translate(movement * Time.fixedDeltaTime);
    }

    IEnumerator TimerLifeObject(float timer)
    {
        isTimer = true;

        transform.localPosition = Vector3.zero;

        textMeshShowTakeMoney.text = " - " + countTakeMoney.ToString();

        GameController.Instance.SetCurrentMoney(-countTakeMoney);

        //print("start corutine");      /////////////////////////////////////////////////////

        yield return new WaitForSeconds(timer);

        //print("stop coroutine");   ///////////////////////////////////////////

        isTimer = false;

        gameObject.SetActive(false);



    }
}
