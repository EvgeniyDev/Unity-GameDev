using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 15f;

    Transform target;
    NavMeshAgent agent;

    EnemyStats enemy;
    PlayerStats player;

    Animator enemyAnimator;
    WeaponInteraction weaponInteraction;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

        enemy = GetComponent<EnemyStats>();
        player = target.GetComponent<PlayerStats>();

        enemyAnimator = GetComponent<Animator>();
        weaponInteraction = player.GetComponent<WeaponInteraction>();
    }

    void Update()
    {
        float distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (distanceToTarget <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distanceToTarget <= agent.stoppingDistance)
            {
                agent.SetDestination(transform.position);
                FaceTarget();

                Attack();
                TakingDamage();
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f); 
    }


    void Attack()
    {
       
    }

    void TakingDamage()
    {
        if (weaponInteraction.isAttacking)
        {
            enemy.TakingDamage(player.damage);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
