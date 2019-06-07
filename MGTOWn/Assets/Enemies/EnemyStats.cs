using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth;
    public int damage;
    public float attackSpeed;

    int currentHealth;

    Animator animator;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Start()
    {
        Awake();
    }

    public void TakingDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {

        Destroy(gameObject);
    }
}
