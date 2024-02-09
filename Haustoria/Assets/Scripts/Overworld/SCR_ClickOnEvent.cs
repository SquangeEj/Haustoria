using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SCR_ClickOnEvent : MonoBehaviour
{
    public ItemClass item;
    [SerializeField] private UnityEvent onClickEvent;

    private void OnMouseDown()
    {
       
        onClickEvent.Invoke();
        
        if(gameObject.tag == "Item")
        {
            AddToInventory();
        }
    }

    private void AddToInventory()
    {
        Inventory_Manager inventoryManager = FindObjectOfType<Inventory_Manager>(); // Find the Inventory_Manager script
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
