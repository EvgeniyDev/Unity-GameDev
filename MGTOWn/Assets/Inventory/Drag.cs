using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    Inventory inventory;

    public static GameObject draggedObject;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("InventoryHolder").GetComponent<Inventory>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        draggedObject = gameObject;
        inventory.dragPrefab.SetActive(true);
        inventory.dragPrefab.GetComponent<CanvasGroup>().blocksRaycasts = false;

        if (draggedObject.GetComponent<CurrentItem>())
        {
            int index = draggedObject.GetComponent<CurrentItem>().index;

            inventory.dragPrefab.GetComponent<Image>().sprite = Resources.Load<Sprite>(inventory.items[index].icon);

            if (inventory.dragPrefab.GetComponent<Image>().sprite == null)
            {
                draggedObject = null;
                inventory.dragPrefab.SetActive(false);
            }

            if (inventory.items[index].itemAmount > 1)
            {
                inventory.dragPrefab.transform.GetChild(0).GetComponent<Text>().text
                    = inventory.items[index].itemAmount.ToString();
            }
            else
            {
                inventory.dragPrefab.transform.GetChild(0).GetComponent<Text>().text = null;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        inventory.dragPrefab.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        draggedObject = null;
        inventory.dragPrefab.SetActive(false);
        inventory.dragPrefab.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
