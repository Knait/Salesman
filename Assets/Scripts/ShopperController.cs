using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// Движение бота скрипт весит на покупателе
/// </summary>
public class ShopperController : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent navMeshAgent;
    [HideInInspector]
    public Vector3 lastPosition;
    [HideInInspector]
    public Transform currentTarget;   // текущая цель

    [Header("Аниматор")]
    [SerializeField]
    private Animator animator;
    [Header("Начальная скорость перемещения")]
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
            animator.SetBool("Walk", true);         // вкл идти
            animator.SetBool("Angry", false);        // выкл недовольного
        }
    }

    /// <summary>
    /// стоп бот
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


    /// <summary>
    /// Сетим состояние аниматора
    /// </summary>
    /// <param name="parametrAnimation"></param>
    /// <param name="flag"></param>
    public void SetAnimatorState(string parametrAnimation, bool flag)
    {
        animator.SetBool(parametrAnimation, flag);
    }
}

