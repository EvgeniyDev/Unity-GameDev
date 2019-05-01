﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    [HideInInspector]
    public List<Item> items;
    public GameObject cellContainer;

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
        if (Input.GetKeyDown(KeyCode.R))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 20f))
            {
                if (hit.collider.GetComponent<Item>())
                {
                    AddItem(hit.collider.GetComponent<Item>());
                }
            }
        }
    }

    void AddItem(Item currentItem)
    {
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
                Destroy(currentItem.gameObject);

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
                Destroy(currentItem.gameObject);

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
                image.sprite = items[i].icon;

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
}