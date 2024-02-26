using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class SCR_Container2 : MonoBehaviour
{
    public Sprite openSprite;

    [Header("Items in Conatainer")]
    public List<ItemClass> items = new List<ItemClass>(); // List of items in the container
    
    [SerializeField] private UnityEvent onClickEvent;

    private bool playerInRange = false;
    private SCR_InventoryManager inventoryManager;
    private SpriteRenderer spriteRenderer;
    private Collider col;
    public TextMeshProUGUI itemNameText;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider>();

        GameObject inventoryManagerObject = GameObject.Find("InventoryManger");
        if (inventoryManagerObject != null)
        {
            inventoryManager = inventoryManagerObject.GetComponent<SCR_InventoryManager>();
        }
        else
        {
            Debug.LogWarning("InventoryManager GameObject not found in the scene.");
        }
    }

    private void Update()
    {

        if (playerInRange && Input.GetMouseButtonDown(0))
        {
            if (items != null && items.Count > 0)
            {
                Debug.Log("CLICK");
                //unity event to show items being added
                onClickEvent.Invoke();
                string txt ="";

                // Add all items to the player's inventory
                foreach (ItemClass item in items)
                {
                    txt += item.itemName + ", ";
                    inventoryManager.Add(item);
                    Debug.Log("Added " + item);
                }
                items.Clear();
                spriteRenderer.sprite = openSprite;
                
                if (col != null)
                {
                    col.enabled = false;
                }

                itemNameText.text = txt + "added to inventory: Press 'I' to open Inventory ";
            }
            else
            {
                Debug.Log("Container is already empty.");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}