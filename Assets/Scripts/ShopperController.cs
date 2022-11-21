using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// �������� ���� ������ ����� �� ����������
/// </summary>
public class ShopperController : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent navMeshAgent;
    [HideInInspector]
    public Vector3 lastPosition;
    [HideInInspector]
    public Transform currentTarget;   // ������� ����

    [Header("��������")]
    [SerializeField]
    private Animator animator;
    [Header("��������� �������� �����������")]
    [SerializeField]
    private float speedBegin = 3.0f;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>() as NavMeshAgent;
        animator = GetComponentInChildren<Animator>();
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
            animator.SetBool("Walk", true);         // ��� ����
            animator.SetBool("Angry", false);        // ���� ������������
        }
    }

    /// <summary>
    /// ���� ���
    /// </summary>
    public void IdleEnemy()
    {
        navMeshAgent.speed = 0;

        if (animator)
        {
            animator.SetBool("Walk", false);
        }
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


    /// <summary>
    /// ����� ��������� ���������
    /// </summary>
    /// <param name="parametrAnimation"></param>
    /// <param name="flag"></param>
    public void SetAnimatorState(string parametrAnimation, bool flag)
    {
        animator.SetBool(parametrAnimation, flag);
    }
}

