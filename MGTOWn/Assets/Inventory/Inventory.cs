using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
//using UnityEditor.VersionControl;
//using System.Timers;
using System.Collections;


public class Inventory : MonoBehaviour
{
    [HideInInspector]
    public List<Item> items;
    public GameObject cellContainer;

    public GameObject dragPrefab;
	public TextMeshProUGUI Hint;

    [Header ("Tooltip")]
    public GameObject tooltipObject;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;
	public GameObject pickupMessage;

    void Awake()
    {
        tooltipObject.SetActive(false);

        pickupMessage.SetActive(false);
    }

    void Start()
    {
        items = new List<Item>();

        for (int i = 0; i < cellContainer.transform.childCount; i++)
        {
            items.Add(new Item());
            cellContainer.transform.GetChild(i).GetComponent<CurrentItem>().index = i;
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 20f))
            {
                if (hit.collider.GetComponent<Item>())
                {
                    AddItem(hit.collider.GetComponent<Item>());
					Hint.text = "";
                }
            }
        }
    }

    public Item LoadItem(int itemId, int itemAmount, bool itemIsStackable,
        string itemName, string itemDescription, string itemPrefab, string itemIcon,
        int itemDamage)
    {
        Item tempItem;

        if (itemId == 0)
        {
            return new Item();
        }

        if (itemId >= 1 && itemId <= 5)
        {
            tempItem = new WeaponItem();
            (tempItem as WeaponItem).baseDamage = itemDamage;
        }
        else
        {
            tempItem = new Item();
        }

        tempItem.id = itemId;
        tempItem.itemAmount = itemAmount;
        tempItem.isStackable = itemIsStackable;
        tempItem.itemName = itemName;
        tempItem.description = itemDescription;
        tempItem.prefab = itemPrefab;
        tempItem.icon = itemIcon;

        return tempItem;

    }

    public void AddItem(Item currentItem)
    {
		ShowMessage (currentItem.itemName);

        if (currentItem.isStackable)
        {
            AddStackable(currentItem);
        }
        else AddUnstackable(currentItem);
    }

    void AddUnstackable(Item currentItem)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].id == 0)
            {
                items[i] = currentItem;
                items[i].itemAmount = 1;

                DisplayItems();
                DestroyImmediate(currentItem.gameObject);

                return;
            }
        }
    }

    void AddStackable(Item currentItem)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].id == currentItem.id)
            {
                items[i].itemAmount++;

                DisplayItems();
                DestroyImmediate(currentItem.gameObject);

                return;
            }
        }

        AddUnstackable(currentItem);
    }

    public void DisplayItems()
    {
        for (int i = 0; i < items.Count; i++)
        {
            Transform cell = cellContainer.transform.GetChild(i);
            Transform icon = cell.GetChild(0);
            Transform amount = icon.GetChild(0);

            Image image = icon.GetComponent<Image>();
            Text text = amount.GetComponent<Text>();

            if (items[i].id != 0)
            {
                image.enabled = true;
                image.sprite = Resources.Load<Sprite>(items[i].icon);

                if (items[i].itemAmount > 1)
                {
                    text.enabled = true;
                    text.text = "x" + items[i].itemAmount;
                }
                else text.enabled = false;
            }
            else
            {
                text.text = null;
                image.enabled = false;
                image.sprite = null;
            }
        }
    }


	//Timer t;
	//bool stopT;

	void ShowMessage(string msg)
    {
		try { // Clear output
			msg = msg.Substring (0, msg.IndexOf ("("));
		}
        catch (Exception){ }

        pickupMessage.SetActive(true);
        pickupMessage.GetComponent<Text>().text = "Added: " + msg;   

		StartCoroutine (Wait ());
	}

	IEnumerator Wait()
    {
		yield return new WaitForSeconds(5);

        pickupMessage.SetActive(false);
        pickupMessage.GetComponent<Text>().text = string.Empty;
    }
}
