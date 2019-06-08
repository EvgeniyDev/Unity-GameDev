using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    GameObject player;

    Inventory inventory;

    public GameObject weaponImageObject;
    public GameObject weaponDamageObject;
    public CurrentWeaponSlot weaponSlot;
    GameObject weapon;
    Image weaponImage;
    Text weaponDamage;
   
    Animator animator;

    public bool isAttacking;

    void Start()
    {
        player = PlayerManager.instance.player;
        inventory = GameObject.FindGameObjectWithTag("InventoryHolder").GetComponent<Inventory>();

        weapon = null;

        weaponImage = weaponImageObject.GetComponent<Image>();
        weaponDamage = weaponDamageObject.GetComponent<Text>();

        weaponImageObject.SetActive(false);
    }

    void Update()
    {
        WeaponPickUp();

        Attack();
    }


    void WeaponPickUp()
    {
        if (inventory.items[weaponSlot.weaponSlotIndex].id != 0)
        {
            weaponImage.sprite = inventory.items[weaponSlot.weaponSlotIndex].icon;
            weaponImageObject.SetActive(true);
            weaponDamage.text = (inventory.items[weaponSlot.weaponSlotIndex] as WeaponItem).baseDamage.ToString();

            if (weapon != null && weapon.name != inventory.items[weaponSlot.weaponSlotIndex].itemName)
            {
                Destroy(weapon);
                Destroy(animator);

                animator = null;
                weapon = null;
            }

            if (weapon == null)
            {
                weapon = Instantiate(Resources.Load<GameObject>(inventory.items[weaponSlot.weaponSlotIndex].prefab))
                    as GameObject;
                weapon.name = inventory.items[weaponSlot.weaponSlotIndex].itemName;

                Destroy(weapon.GetComponent<Rigidbody>());
                Destroy(weapon.GetComponent<Collider>());

                if (animator == null)
                {
                    animator = weapon.AddComponent<Animator>();
                    animator.runtimeAnimatorController = Resources.Load("Weapons/Controllers/"
                        + weapon.name) as RuntimeAnimatorController;
                }

                weapon.transform.parent = player.transform.GetChild(0).transform;
            }
        }
        else
        {
            if (weapon != null && inventory.items[weaponSlot.weaponSlotIndex].id == 0)
            {
                Destroy(weapon);
                Destroy(animator);

                animator = null;
                weapon = null;
            }

            weaponImageObject.SetActive(false);
            weaponDamage.text = "";
        }
    }

    public void Attack()
    {
        if (weapon != null && Input.GetButtonDown("Fire1") && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            int animAmount = 2;

            animator.SetTrigger("Attack");
            animator.SetInteger("randomAttack", Random.Range(0, animAmount));

            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
    }
}
