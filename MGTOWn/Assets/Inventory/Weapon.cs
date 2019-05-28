using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    GameObject player;

    Inventory inventory;

    public GameObject weaponImageObject;
    public CurrentWeaponSlot weaponSlot;
    GameObject weapon;
    Image weaponImage;

    Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = GameObject.FindGameObjectWithTag("InventoryHolder").GetComponent<Inventory>();

        weapon = null;

        weaponImage = weaponImageObject.GetComponent<Image>();
        weaponImageObject.SetActive(false);
    }

    void Update()
    {
        if (inventory.items[weaponSlot.weaponSlotIndex].id != 0)
        {
            weaponImage.sprite = inventory.items[weaponSlot.weaponSlotIndex].icon;
            weaponImageObject.SetActive(true);

            if (weapon != null && weapon.name != inventory.items[weaponSlot.weaponSlotIndex].itemName)
            {
                Destroy(weapon);
                weapon = null;
            }

            if (weapon == null)
            {
                weapon = Instantiate(Resources.Load<GameObject>(inventory.items[weaponSlot.weaponSlotIndex].prefab))
                    as GameObject;
                weapon.name = inventory.items[weaponSlot.weaponSlotIndex].itemName;

                Destroy(weapon.GetComponent<Rigidbody>());
                Destroy(weapon.GetComponent<Collider>());

                animator = weapon.AddComponent<Animator>();
                animator.runtimeAnimatorController = Resources.Load("Weapons/Weapon") as RuntimeAnimatorController;
                
                weapon.transform.parent = player.transform.GetChild(0);
                weapon.transform.localPosition = SetWeaponPosition(weapon);
                weapon.transform.localEulerAngles = SetWeaponRotation(weapon);
            }
        }
        else
        {
            if (weapon != null && inventory.items[weaponSlot.weaponSlotIndex].id == 0)
            {
                Destroy(weapon);
                weapon = null;
            }

            weaponImageObject.SetActive(false);
        }

        PlayAnimation();
    }


    Vector3 SetWeaponPosition(GameObject weapon)
    {
        Vector3 temp = new Vector3();

        switch (weapon.name)
        {
            case "Weapon №5":
                goto case "Sword";
            case "Sword":
                temp = new Vector3(1.5f, -3.75f, 2.5f);
                break;
            case "Axe":
                temp = new Vector3(1f, -3f, 2.2f);
                break;
            case "Mace":
                temp = new Vector3(1.25f, -2.75f, 2.2f);
                break;
            case "Knife":
                temp = new Vector3(1f, -1.5f, 0.5f);
                break;
        }

        return temp;
    }

    Vector3 SetWeaponRotation(GameObject weapon)
    {
        Vector3 temp = new Vector3();

        switch (weapon.name)
        {
            case "Mace":
                goto case "Axe";
            case "Weapon №5":
                temp = new Vector3(-115f, -105f, -170f);
                break;
            case "Sword":
                temp = new Vector3(120f, 70f, 150f);
                break;
            case "Axe":
                temp = new Vector3(-70f, 80f, 0f);
                break;
            case "Knife":
                temp = new Vector3(25f, -150f, 95f);
                break;
        }

        return temp;
    }

    void PlayAnimation()
    {
        if (weapon != null && Input.GetMouseButton(0))
        {
            if (weapon.name == "Knife")
            {
                animator.Play("Knife stab");
                return;
            }

            switch (Random.Range(-100, 100) % 2)
            {
                case 0:
                    animator.Play("Stab");
                    break;
                case 1:
                    animator.Play("Splash");
                    break;
            }
        }
    }
}
