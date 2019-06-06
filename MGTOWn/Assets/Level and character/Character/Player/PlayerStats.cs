using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Inventory inventory;
    public CurrentWeaponSlot weaponSlot;

    [HideInInspector]
    public int damage;

    int maxHealth;
    int currentHealth;

    void Awake()
    {
        damage = 0;
        maxHealth = 100;
        currentHealth = maxHealth;
    }

    void Update()
    {
        WeaponDamageUpdate();
    }

    void WeaponDamageUpdate()
    {
        if (inventory.items[weaponSlot.weaponSlotIndex].id != 0)
        {
            damage = (inventory.items[weaponSlot.weaponSlotIndex] as WeaponItem).baseDamage;
        }
        else
        {
            damage = 0;
        }
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

    }
}
