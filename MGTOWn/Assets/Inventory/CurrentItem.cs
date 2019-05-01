using UnityEngine;
using UnityEngine.EventSystems;

public class CurrentItem : MonoBehaviour, IPointerClickHandler
{
    [HideInInspector]
    public int index;

    GameObject inventoryObject;
    Inventory inventory;

    GameObject droppedItem;

    void Start()
    {
        inventoryObject = GameObject.FindGameObjectWithTag("InventoryHolder");
        inventory = inventoryObject.GetComponent<Inventory>();

        droppedItem = null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (inventory.items[index].id != 0)
            {
                droppedItem = Instantiate(inventory.items[index].prefab) as GameObject;
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
}
