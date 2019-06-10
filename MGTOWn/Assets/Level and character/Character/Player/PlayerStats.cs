using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public Inventory inventory;
    public CurrentWeaponSlot weaponSlot;

    public TMP_Text healthbarText;
    public Slider healthbarSlider;
    public Image damageFadeOut;

    public DeathScript deathScript;

    [HideInInspector]
    public int damage;

    int maxHealth;
    int currentHealth;

    bool isRegenerating;

    void Start()
    {
        damage = 0;
        maxHealth = 100;
        currentHealth = maxHealth;
        healthbarSlider.maxValue = maxHealth;
        healthbarSlider.value = currentHealth;
    }

    void Update()
    {
        WeaponDamageUpdate();

        CurrentHealthDisplay();
        Regeneration();
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

        StartCoroutine(DamageTakingColorChange());

        if (currentHealth <= 0)
        {
            currentHealth = 0;

            deathScript.Die();
        }
    }

    void CurrentHealthDisplay()
    {
        healthbarSlider.value = currentHealth;
        healthbarText.text = currentHealth + "/" + maxHealth;
    }

    void Regeneration()
    {
        if (currentHealth < maxHealth && !isRegenerating && Time.timeScale != 0 
            && currentHealth >= 1)
        {
            StartCoroutine(RegenerationDelay());
        }
    }

    IEnumerator DamageTakingColorChange()
    {
        Color tempColor = damageFadeOut.color;

        for (float alpha = 0.5f; alpha >= -0.05f; alpha -= 0.025f)
        {
            tempColor.a = alpha;
            damageFadeOut.color = tempColor;
            yield return new WaitForSeconds(0.0125f);
        }
    }

    IEnumerator RegenerationDelay()
    {
        isRegenerating = true;

        yield return new WaitForSeconds(1f);
        currentHealth += 1;

        isRegenerating = false;
    }
}
