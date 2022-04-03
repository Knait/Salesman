//����� �� ������
// 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// �������� ��������� � ��������
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class MoveController : MonoBehaviour
{
    private Rigidbody rigidBody;

    [Header("Rotate")]
    [SerializeField]
    private GameObject visualPlayer;

    [Header("��������� ��������")]
    [SerializeField]
    private float speedBegin;

    private float speedStart;

    // [SerializeField]
    [Header("�������� Upgrade ��������")]
    private float multiPlay;

    //[SerializeField]
    private int upgradeSpeedHeroLevel;      //  // ������� Level SpeedHero

    private float speed;       // ������� ��������

    [Header("��������")]
    [SerializeField]
    private Animator animator;


    /// <summary>
    /// ���� �������
    /// </summary>
    //[HideInInspector]
    public bool isBox;


    private float horizMove;
    private float verticalMove;




    private void Start()
    {
        speedStart = GameSettings.Instance.speedStart;
        multiPlay = GameSettings.Instance.multiPlay;


        animator = GetComponentInChildren<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        //speedBegin *= 2;
    }

    private void Update()
    {
        if (GameController.Instance.stateGame == StateGame.Game)
        {
            upgradeSpeedHeroLevel = GameController.Instance.upgradeSpeedHeroLevel;
            speedBegin = speedStart + upgradeSpeedHeroLevel * multiPlay;
        }

        UpdateMove();

    }

    void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// ������� ������
    /// </summary>
    private void Move()
    {
        Vector3 movement = new Vector3(verticalMove, 0, horizMove) * speed;
        transform.Translate(movement * Time.fixedDeltaTime);

        //speed *= 5;
        //Vector3 movement = new Vector3(verticalMove, 0, horizMove) * speed;
        //rigidBody.AddForce(movement);
        //rigidBody.velocity = movement;
    }


    void UpdateMove()
    {
        horizMove = JoystickStick.Instance.VerticalAxis();
        verticalMove = JoystickStick.Instance.HorizontalAxis();

        if ((horizMove == 0.0f && verticalMove == 0.0f) || (GameController.Instance.stateGame != StateGame.Game))
        {
            if (animator)
            {
                animator.SetBool("Run", false);
                animator.SetBool("RunWithBox", false);

                speed = 0;
                rigidBody.velocity = Vector3.zero;
            }
            return;
        }
        else
        {
            speed = speedBegin;
        }

        float angle = Mathf.Atan2(verticalMove, horizMove) * Mathf.Rad2Deg;
        visualPlayer.transform.rotation = Quaternion.Euler(0, angle, 0);

        if (animator)
        {
            if (speed == speedBegin)
            {
                if (!isBox)
                {
                    animator.SetBool("Run", true);
                    animator.SetBool("RunWithBox", false);
                }
                else
                {
                    animator.SetBool("RunWithBox", true);
                    animator.SetBool("Run", false);
                }
            }

        }
    }

    public void SetAnimatorWithBox(bool flag)
    {
        animator.SetBool("IsBox", flag);
        isBox = flag;
    }

}


