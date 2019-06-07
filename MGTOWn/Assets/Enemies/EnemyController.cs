using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius;

    Transform target;
    NavMeshAgent agent;

    EnemyStats enemy;
    PlayerStats player;

    Animator enemyAnimator;
    PlayerController playerController;

    Color defaultColor;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

        enemy = GetComponent<EnemyStats>();
        player = target.GetComponent<PlayerStats>();

        enemyAnimator = GetComponent<Animator>();
        playerController = player.GetComponent<PlayerController>();

        defaultColor = gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color;
    }

    void Update()
    {
        float distanceToTarget = Vector3.Distance(target.position, transform.position);

        enemyAnimator.SetFloat("Distance", distanceToTarget);

        if (distanceToTarget <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distanceToTarget <= agent.stoppingDistance)
            {
                agent.SetDestination(transform.position);
                FaceTarget();

                TakingDamage();
            }
        }
        else
        {
            agent.SetDestination(transform.position);
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
        player.TakingDamage(enemy.damage);        
    }

    void TakingDamage()
    {
        if (playerController.isAttacking)
        {
            StartCoroutine(DamageDelay());
        }
    }

    IEnumerator DamageDelay()
    {
        yield return new WaitForSeconds(0.5f);
        enemy.TakingDamage(player.damage);

        StartCoroutine(DamageColorChange());
    }

    IEnumerator DamageColorChange()
    {
        gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.15f);
        gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = defaultColor;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
