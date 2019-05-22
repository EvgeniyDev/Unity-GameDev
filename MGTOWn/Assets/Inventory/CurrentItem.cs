using UnityEngine;
using UnityEngine.EventSystems;

public class CurrentItem : MonoBehaviour, IPointerClickHandler, IDropHandler 
{
    [HideInInspector]
    public int index;

    GameObject inventoryObject;
    CurrentWeaponSlot weaponSlot;
    Inventory inventory;

    void Start()
    {
        inventoryObject = GameObject.FindGameObjectWithTag("InventoryHolder");
        weaponSlot = GameObject.FindGameObjectWithTag("Weapon").GetComponent<CurrentWeaponSlot>();
        inventory = inventoryObject.GetComponent<Inventory>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (inventory.items[index].id != 0)
            {
                GameObject droppedItem = Instantiate(Resources.Load<GameObject>(inventory.items[index].prefab));

                droppedItem.name = inventory.items[index].itemName;
                droppedItem.transform.position = Camera.main.transform.position + 2 * Camera.main.transform.forward;

                if (inventory.items[index].itemAmount > 1)
                {
                    inventory.items[index].itemAmount--;
                }
                else
                {
                    inventory.items[index] = new Item();
                }

                inventory.DisplayItems();
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject draggedObject = Drag.draggedObject;

        if (draggedObject == null)
        {
            return;
        }

        CurrentItem currentDraggedItem = draggedObject.GetComponent<CurrentItem>();

        if (currentDraggedItem != null)
        {
            if (inventory.items[currentDraggedItem.index].type != Item.Type.Weapon
                && weaponSlot.isOver) 
            {
                return;
            }

            if (inventory.items[currentDraggedItem.index].type != inventory.items[GetComponent<CurrentItem>().index].type
                && inventory.items[weaponSlot.weaponSlotIndex].id == inventory.items[currentDraggedItem.index].id
                && inventory.items[GetComponent<CurrentItem>().index].id != 0)
            {
                return;
            }

            //swap
            Item currentItem = inventory.items[GetComponent<CurrentItem>().index];
            inventory.items[GetComponent<CurrentItem>().index] = inventory.items[currentDraggedItem.index];
            inventory.items[currentDraggedItem.index] = currentItem;
                       
            inventory.DisplayItems();
        }
    }
}

