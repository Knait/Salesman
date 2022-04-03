
// ГАВНА скрипт весит на покупателе
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// Движение бота
/// </summary>
public class ShopperController : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent navMeshAgent;

    //[HideInInspector]
    public Transform currentTarget;   // текущая цель

    [Header("Аниматор")]
    [SerializeField]
    private Animator animator;

    [Header("Начальная скорость перемещения")]
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
    /// Обновление движения
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
    /// побежал бот
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
    /// стоп бот
    /// </summary>
    public void IdleEnemy()
    {
        navMeshAgent.speed = 0;

        if (animator) animator.SetBool("Run", false);
    }


    /// <summary>
    /// обновляем цель
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

