using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CurrentWeapon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject weaponImageObject;

    Inventory inventory;
    GameObject inventoryObject;

    Image weaponImage;

    [HideInInspector]
    public int weaponSlotIndex;

    [HideInInspector]
    public bool isOver;

    void Start()
    {
        isOver = false;

        weaponImage = weaponImageObject.GetComponent<Image>();
        weaponImageObject.SetActive(false);

        inventoryObject = GameObject.FindGameObjectWithTag("InventoryHolder");
        inventory = inventoryObject.GetComponent<Inventory>();

        for (int i = 0; i < inventory.cellContainer.transform.childCount; i++)
        {
            if (inventory.cellContainer.transform.GetChild(i).GetComponent<CurrentWeapon>() != null)
            {
                weaponSlotIndex = i;
                return;
            }
        }
    }

    void Update()
    {
        if (inventory.items[weaponSlotIndex].id != 0)
        {
            weaponImage.sprite = inventory.items[weaponSlotIndex].icon;
            weaponImageObject.SetActive(true);
        }
        else
        {
            weaponImageObject.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOver = !isOver;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnPointerEnter(eventData);
    }
}
