
// ����� ������ ����� �� ����������
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// �������� ����
/// </summary>
public class ShopperController : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent navMeshAgent;

    //[HideInInspector]
    public Transform currentTarget;   // ������� ����

    [Header("��������")]
    [SerializeField]
    private Animator animator;

    [Header("��������� �������� �����������")]
    [SerializeField]
    private float speedBegin = 3.0f;

    [HideInInspector]
    public Vector3 lastPosition;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>() as NavMeshAgent;
        animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {

    }


    void Update()
    {
        UpdateMove();
        UpdateTarget();
    }

    /// <summary>
    /// ���������� ��������
    /// </summary>
    void UpdateMove()
    {
        if (GameController.Instance.stateGame == StateGame.Game)
        {
            if (navMeshAgent.speed > 0)
            {
                RunEnemy();
            }
            else
            {
                IdleEnemy();
            }
        }
        
    }

    /// <summary>
    /// ������� ���
    /// </summary>
    void RunEnemy()
    {
        if (animator)
        {
            //if (navMeshAgent.speed == speedBegin)
            //{
            animator.SetBool("Run", true);
            // }
        }
    }

    /// <summary>
    /// ���� ���
    /// </summary>
    public void IdleEnemy()
    {
        navMeshAgent.speed = 0;

        if (animator) animator.SetBool("Run", false);
    }


    /// <summary>
    /// ��������� ����
    /// </summary>
    void UpdateTarget()
    {
        if (currentTarget && GameController.Instance.stateGame == StateGame.Game)
        {
            navMeshAgent.destination = currentTarget.position;
            navMeshAgent.speed = speedBegin;
        }
        else
        {
            navMeshAgent.speed = 0;
            IdleEnemy();
        }
    }
}

