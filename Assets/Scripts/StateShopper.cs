using System.Collections;
using UnityEngine;

/// <summary>
/// ��������� ����
/// </summary>
public enum StateBot
{
    Start,
    Walk,
    Buy,
    Exit
}

public class StateShopper : MonoBehaviour
{
    [Header("����� �� ParticleSystem")]
    public ParticleSystem particleSys;
    [HideInInspector]
    public StateBot stateBot;
    [HideInInspector]
    public Transform currentTarget;   // ������� ����
    [HideInInspector]
    public Transform currentStartPosition;

    [Header("����� �� �����")]
    [SerializeField]
    private Transform bag;
    [SerializeField]
    private ShopperController shopperController;

    /// <summary>
    ///  ����� �������� �������
    /// </summary>
    [SerializeField]
    private float timerBuy;
    /// <summary>
    /// ������ UI �������
    /// </summary>
    [SerializeField]
    private float countTimer;
    /// <summary>
    ///������ �� ��������
    /// </summary>
    private Coroutine showCalcTimer;

    void Start()
    {
        shopperController = GetComponent<ShopperController>();
        timerBuy = GameSettings.Instance.startTimerWaitClient;          // ����� �������� �������
    }

    private void OnEnable()
    {
        SetStateBag(false, 1);             // ���� �����
    }

    void Update()
    {
        UpdateStateShopper();
    }

    /// <summary>
    /// ��������� ����������
    /// </summary>
    private void UpdateStateShopper()
    {
        switch (stateBot)
        {
            case StateBot.Start:

                break;

            case StateBot.Walk:
                shopperController.currentTarget = currentTarget;               // ����� ���� ���������� �� ����� �������
                break;

            case StateBot.Buy:
                shopperController.currentTarget = null;            // ����� ���� ����������
                break;

            case StateBot.Exit:
                shopperController.currentTarget = currentStartPosition;         // ����� ���� ���������� �� ����� 
                SetTimerUI();
                break;
        }
    }

    /// <summary>
    /// ��� � ������ �����
    /// </summary>
    /// <param name="isActive">��� ���� </param>
    /// <param name="IDMaterialClothes">����</param>
    public void SetStateBag(bool isActive, int IDMaterialClothes)
    {
        bag.gameObject.SetActive(isActive);     // ��� ���� �����
        bag.GetComponent<MeshRenderer>().material = GameSettings.Instance.arrayMaterial[IDMaterialClothes];          // ������ �����
        if (shopperController)
        {
            shopperController.SetAnimatorState("IsBag", isActive);
        }
    }

    

    /// <summary>
    /// ��������� �������
    /// </summary>
    public void SetStateBuy()
    {
        if (stateBot == StateBot.Walk)
        {
            StartCoroutine(TimerBuy(timerBuy));    ///��� �������� �������
            stateBot = StateBot.Buy;                  // ����� ���������� � Buy
        }
    }

    /// <summary>
    /// ������ �������� �������
    /// </summary>
    /// <param name="timerBuy"></param>
    /// <returns></returns>
    private IEnumerator TimerBuy(float timerBuy)
    {
        showCalcTimer = StartCoroutine(ShowCalcTimer());
        yield return new WaitForSeconds(timerBuy);
        stateBot = StateBot.Exit;
    }

    /// <summary>
    /// �������� UI �������
    /// </summary>
    /// <returns></returns>
    private IEnumerator ShowCalcTimer()
    {
        while (true)
        {
            countTimer += Time.deltaTime;
            CheckAngry();
            yield return new WaitForEndOfFrame();
        }
    }

    /// <summary>
    /// ��������� ������������
    /// </summary>
    private void CheckAngry()
    {
        float deltaTimer = timerBuy - countTimer;           // ����� ����� ��� ������������
        if (deltaTimer < GameSettings.Instance.timerAngry)
        {
            shopperController.SetAnimatorState("Angry", true);    /// ��� ������������
        }
    }


    /// <summary>
    /// ���� ������ �� ����� ����� ����
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        PointSpawn pointSpawn = other.GetComponent<PointSpawn>();
        if (pointSpawn)
        {
            if (stateBot == StateBot.Exit)
            {
                gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// ������ �������� ��� UI �������
    /// </summary>
    /// <returns></returns>
    public float �alculationValueTimerUi()
    {
        float result = 0;
        result = countTimer / timerBuy;
        return result;
    }

    /// <summary>
    /// ��������� UI ������
    /// </summary>
    private void SetTimerUI()
    {
        StopCoroutine(showCalcTimer);
        countTimer = 0;
    }

    public void PlayParticle()
    {
        if (particleSys)
        {
            particleSys.Play();
        }
    }
}
