using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class SCR_ClickOnEvent : MonoBehaviour
{
    public ItemClass item;
    [SerializeField] private UnityEvent onClickEvent;
    
    private SCR_InventoryManager inventoryManager;

    private void OnMouseDown()
    {
       
        onClickEvent.Invoke();

        if( item != null)
        {
            AddToInventory();
        }

    }

    private void AddToInventory()
    {
        GameObject inventoryManagerObject = GameObject.Find("InventoryManger");
        if (inventoryManagerObject != null)
        {
            inventoryManager = inventoryManagerObject.GetComponent<SCR_InventoryManager>();
        }
        if (inventoryManager != null)
        {
            bool added = inventoryManager.Add(item); // Add the item to the inventory
            if (added)
            {
                Debug.Log("Item added to inventory: " + item.itemName);
                Destroy(gameObject); // Remove the item from the game world
            }
            else
            {
                Debug.Log("Inventory full, cannot add item: " + item.itemName);
            }
        }
    }
   
    }
