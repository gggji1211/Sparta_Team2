using System.Collections;
using UnityEngine;


public class BossAI : MonoBehaviour
{
    public enum BossState { Idle, Chase }

    public BossState currentState = BossState.Idle;

    public Transform player;
    private bool isEnraged = false;
    public float moveSpeed = 2f;

    public float moveSpeedUp = 1.5f;

    public float bossHp = 100f;

    public float detectionRange = 5f;

    public float attackRange = 1.5f;

    private Rigidbody2D boss;

    private Vector2 movement;

    void Start()
    { 
        boss = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        CheckEnrage(bossHp);

        switch (currentState)
        {
            case BossState.Idle: 
                if (distance < detectionRange) 
                {
                    currentState = BossState.Chase; 
                }
                break;

            case BossState.Chase:
                if (distance <= attackRange)
                {
                    AttackPlayer();
                }
                else
                {
                    ChasePlayer(); 
                }
                break;
        }
    }

    void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;

        movement = direction * moveSpeed;

        boss.velocity = movement;
    }

    void AttackPlayer()
    {
        
            Debug.Log("보스가 플레이어를 공격함!");
         
    }

    void CheckEnrage(float currentHealth)
    {
        if ( isEnraged && bossHp <= 30)
        {
            isEnraged = true;
            moveSpeed *= moveSpeedUp;
            Debug.Log("보스분노 속도 증가");
        }
    }
}




