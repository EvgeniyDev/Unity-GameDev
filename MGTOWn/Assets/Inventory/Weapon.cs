using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    GameObject player;

    public GameObject weaponImageObject;
    public CurrentWeaponSlot weaponSlot;
    GameObject weapon;
    Image weaponImage;

    Inventory inventory;


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

            if (weapon == null)
            {
                weapon = Instantiate(Resources.Load<GameObject>(inventory.items[weaponSlot.weaponSlotIndex].prefab));
                weapon.name = inventory.items[weaponSlot.weaponSlotIndex].itemName;

                weapon.transform.parent = player.transform;
                weapon.transform.position = new Vector3(0, 0, 0);

                Destroy(weapon.GetComponent<Rigidbody>());
                Destroy(weapon.GetComponent<Collider>());
            }
            else
            {
                weapon.transform.position = player.transform.position + new Vector3(1.5f, -1, 1.5f);
                weapon.transform.rotation = new Quaternion(-75, 50, 50, 1);
            }
        }
        else
        {
            if (inventory.items[weaponSlot.weaponSlotIndex].id == 0)
            {
                Destroy(weapon);
                weapon = null;
            }

            weaponImageObject.SetActive(false);
        }
    }
}
