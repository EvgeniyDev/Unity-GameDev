using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerStats : MonoBehaviour
{
    public FirstPersonController playerController;

    public Inventory inventory;
    public CurrentWeaponSlot weaponSlot;

    public TMP_Text healthbarText;
    public Slider healthbarSlider;
    public Slider staminaSlider;
    public Image damageFadeOut;

    public DeathScript deathScript;

    [HideInInspector]
    public int damage;

    [HideInInspector]
    public int maxHealth;
    [HideInInspector]
    public int currentHealth;

    [HideInInspector]
    public int maxStamina;
    [HideInInspector]
    public int currentStamina;

    bool isRegenerating;
    bool isRelaxing;

    void Start()
    {
        damage = 0;

        maxHealth = 100;
        currentHealth = maxHealth;
        healthbarSlider.maxValue = maxHealth;
        healthbarSlider.value = currentHealth;

        maxStamina = 2000;
        currentStamina = maxStamina;
        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = currentStamina;
    }

    void Update()
    {
        WeaponDamageUpdate();

        CurrentStatsDisplay();

        HealthRegeneration();
        StaminaRegeneration();                        
    }

    void FixedUpdate()
    {
        StaminaReduce();
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

    void CurrentStatsDisplay()
    {
        healthbarSlider.value = currentHealth;
        healthbarText.text = currentHealth + "/" + maxHealth;

        staminaSlider.value = currentStamina;
    }

    void StaminaReduce()
    {
        if (!playerController.m_IsWalking)
        {
            if (currentStamina <= maxStamina && currentStamina >= 1
                && Time.timeScale != 0
                && playerController.m_MoveDir.x != 0 || playerController.m_MoveDir.z != 0)
            {
                currentStamina -= 1;
            }
        }

        if (currentStamina < 0)
        {
            currentStamina = 0;
        }
    }

    void HealthRegeneration()
    {
        if (currentHealth < maxHealth && !isRegenerating && Time.timeScale != 0 
            && currentHealth >= 1)
        {
            StartCoroutine(HealthRegenerationDelay());
        }
    }

    void StaminaRegeneration()
    {
        if (currentStamina < maxStamina && !isRelaxing && Time.timeScale != 0
            && currentStamina >= 0)
        {
            StartCoroutine(StaminaRegenerationDelay());
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

    IEnumerator HealthRegenerationDelay()
    {
        isRegenerating = true;

        yield return new WaitForSeconds(1f);
        currentHealth += 1;

        isRegenerating = false;
    }

    IEnumerator StaminaRegenerationDelay()
    {
        isRelaxing = true;

        yield return new WaitForSeconds(0.05f);
        currentStamina += 1;

        isRelaxing = false;
    }
}
