using UnityEngine;

public class BossAI : MonoBehaviour
{
    public enum BossState { Idle, Chase }
    public BossState currentState = BossState.Idle;

    public Transform player;
    public float moveSpeed = 2f;
    public float detectionRange = 5f;

    private Rigidbody2D boss;
    private Vector2 movement;

    void Start()
    {
        boss = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        switch (currentState)
        {
            case BossState.Idle:
                if (distance < detectionRange)
                {
                    currentState = BossState.Chase;
                }
                break;

            case BossState.Chase:
                ChasePlayer();
                break;
        }
    }

    void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        movement = direction * moveSpeed;
        boss.velocity = movement;
    }
}
