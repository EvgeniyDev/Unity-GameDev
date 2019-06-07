using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public Inventory inventory;
    public CurrentWeaponSlot weaponSlot;
    public TMP_Text healthbarText;

    public GameObject damageTakingPanel;
    Image damageFadeOut;

    [HideInInspector]
    public int damage;

    int maxHealth;
    int currentHealth;

    bool isRegenerating;

    void Awake()
    {
        damage = 0;
        maxHealth = 100;
        currentHealth = maxHealth;

        damageFadeOut = damageTakingPanel.GetComponent<Image>();
        damageFadeOut.canvasRenderer.SetAlpha(1);

        //damageTakingPanel.SetActive(false);
    }

    void Update()
    {
        WeaponDamageUpdate();

        CurrentHealthDisplay();
        Regeneration();

        damageFadeOut.CrossFadeAlpha(1, 0.5f, false);
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
            currentHealth = 0;
            Die();
        }
    }

    void CurrentHealthDisplay()
    {
        healthbarText.text = currentHealth + "/" + maxHealth;
    }

    void Regeneration()
    {
        if (currentHealth < maxHealth && !isRegenerating 
            && Time.timeScale != 0)
        {
            StartCoroutine(RegenerationDelay());
        }
    }

    IEnumerator RegenerationDelay()
    {
        isRegenerating = true;

        yield return new WaitForSeconds(1f);
        currentHealth += 1;

        isRegenerating = false;
    }

    void Die()
    {

    }
}
