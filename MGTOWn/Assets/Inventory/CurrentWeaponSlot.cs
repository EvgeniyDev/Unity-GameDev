using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CurrentWeaponSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Inventory inventory;
    GameObject inventoryObject;

    Image weaponImage;

    [HideInInspector]
    public int weaponSlotIndex;

    public bool isOver;

    void Start()
    {
        isOver = false;

        inventoryObject = GameObject.FindGameObjectWithTag("InventoryHolder");
        inventory = inventoryObject.GetComponent<Inventory>();

        for (int i = 0; i < inventory.cellContainer.transform.childCount; i++)
        {
            if (inventory.cellContainer.transform.GetChild(i).GetComponent<CurrentWeaponSlot>() != null)
            {
                weaponSlotIndex = i;
                return;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOver = false;
    }
}
