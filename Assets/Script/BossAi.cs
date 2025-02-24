using System.Collections;
using UnityEngine;


public class BossAI : MonoBehaviour
{
    public enum BossState { Idle, Chase }

    public BossState currentState = BossState.Idle;

    public Transform player;
    private bool isEnraged = false;
    public float moveSpeed = 2f;

    public float dashSpeed = 10f; // �뽬 �ӵ�
    public float dashCooldown = 3f; // �뽬 ��Ÿ��
    private float lastDashTime;

    public float moveSpeedUp = 1.5f; // ���ǵ��

    public float bossHp = 100f;

    public float detectionRange = 5f; //�νİŸ�

    public float attackRange = 1.5f; //��Ÿ�

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
    void DashAttack()
    {
        if (Time.time - lastDashTime > dashCooldown)
        {
            Vector2 dashDirection = (player.position - transform.position).normalized;
            boss.velocity = dashDirection * dashSpeed;
            lastDashTime = Time.time;
            Debug.Log("������ �뽬 ����");
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
        
            Debug.Log("������ �÷��̾ ������!");
         
    }

    void CheckEnrage(float currentHealth)
    {
        if ( isEnraged && bossHp <= 30)
        {
            isEnraged = true;
            moveSpeed *= moveSpeedUp;
            Debug.Log("�����г� �ӵ� ����");
        }
    }
}




