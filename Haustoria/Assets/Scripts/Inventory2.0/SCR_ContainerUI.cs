using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SCR_ContainerUI : MonoBehaviour
{
    [SerializeField] private GameObject slotHolder;
    [SerializeField] private GameObject itemPrefab;

    private GameObject[] slots;
    private List<SlotClass> items = new List<SlotClass>(); // Updated to private

    private SCR_InventoryManager inventoryManager;
    private SCR_Container container;

    private void Start()
    {
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

    public void SetContainer(SCR_Container _container)
    {
        container = _container;
        items = container.items;
        RefreshUI();
    }

    public void RefreshUI()
    {
        // Destroy previously instantiated UI slots
        foreach (Transform child in slotHolder.transform)
        {
            Destroy(child.gameObject);
        }

        // Instantiate UI slots for items in the container
        GridLayoutGroup gridLayout = slotHolder.GetComponent<GridLayoutGroup>();
        int numSlots = gridLayout.constraintCount * gridLayout.constraintCount;
        slots = new GameObject[numSlots];
        for (int i = 0; i < numSlots; i++)
        {
            GameObject slot = Instantiate(itemPrefab, slotHolder.transform);
            slots[i] = slot;
            Button button = slot.GetComponentInChildren<Button>();
            int index = i;
            button.onClick.AddListener(() => OnSlotClicked(index));
        }

        // Populate UI slots with item information
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].GetItem().itemSprite;
                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = items[i].GetItem().itemName;
                if (items[i].GetItem().isStackable)
                    slots[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = items[i].GetQuantity().ToString();
                else
                    slots[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "";
            }
            else
            {
                // If there are fewer items than slots, hide remaining slots
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
                slots[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "";
            }
        }
    }

    private void OnSlotClicked(int index)
    {
        ItemClass item = items[index].GetItem();
        TransferItem(item);
    }

    private void TransferItem(ItemClass item)
    {
        if (inventoryManager != null)
        {

            // Add the item to the inventory
            inventoryManager.Add(item);
            Debug.LogWarning("Adding To Inventory." + item.itemName);
            // Find the slot containing the item
            SlotClass slotContainingItem = items.Find(slot => slot.GetItem() == item);
            // Remove the slot from the container
            if (slotContainingItem != null)
                items.Remove(slotContainingItem);

            // Refresh the UI
            RefreshUI();
        }
        else
        {
            Debug.LogWarning("InventoryManager reference is null.");
        }
    }

}