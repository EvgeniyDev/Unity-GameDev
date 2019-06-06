using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth;
    public int damage;

    int currentHealth;

    Animator animator;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        Awake();
    }

    public void TakingDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log(currentHealth);

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
