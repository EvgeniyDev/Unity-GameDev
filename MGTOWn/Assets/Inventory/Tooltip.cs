using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Inventory inventory;
    
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("InventoryHolder").GetComponent<Inventory>();
    }

    void Update()
    {
        inventory.tooltipObject.transform.position = Input.mousePosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        CurrentItem currentItem = GetComponent<CurrentItem>();
        Item item = inventory.items[currentItem.index];

        if (item.id != 0)
        {
            inventory.tooltipObject.SetActive(true);

            inventory.itemName.text = item.itemName;
            inventory.itemDescription.text = item.description;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        inventory.tooltipObject.SetActive(false);
    }
}
