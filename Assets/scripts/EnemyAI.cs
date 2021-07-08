using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask

            whatIsGround,
            whatIsPlayer;

    public float health;

    public AudioSource shootSound;

    //attack
    public float timeBetweenAttacks;

    bool alreadyAttacked;

    public GameObject projectile;

    //states
    public float

            sightRange,
            attackRange;

    public bool

            playerInSightRange,
            playerInAttackRange;

    public void Awake()
    {
        player = GameObject.Find("PLayer").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        //Check for sight and attack range
        playerInSightRange =
            Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange =
            Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    public void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    public void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt (player);

        if (!alreadyAttacked)
        {
            playSoundEffect();
            Rigidbody rb =
                Instantiate(projectile, transform.position, transform.rotation)
                    .GetComponent<Rigidbody>();
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    public void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), .5f);
    }

    public void DestroyEnemy()
    {
        Destroy (gameObject);
    }

    public void playSoundEffect()
    {
        shootSound.Play();
    }
}
