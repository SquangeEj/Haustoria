using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SCR_InventoryManager : MonoBehaviour, IDataPersistance
{
    [SerializeField] public SCR_BriarStats briarStats;
    [SerializeField] private GameObject slotHolder;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private GameObject slotWeapon;

    public List<SlotClass> items = new List<SlotClass>();

    private GameObject[] slots;


    private void Start()
    {
        int numSlots = 100;
        slots = new GameObject[numSlots];

        for (int i = 0; i < numSlots; i++)
        {
            GameObject slot = Instantiate(slotPrefab, slotHolder.transform);
            slots[i] = slot;

            // Add an onClick listener to the button component of each slot
            Button button = slot.GetComponentInChildren<Button>();
            int index = i; // Create a local variable to capture the current index
            button.onClick.AddListener(() => OnSlotClicked(index));
        }

        RefreshUI();
    }

    public void RefreshUI()
    {

        for (int i = 0; i < slots.Length; i++)
        {
            try
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].GetItem().itemSprite;
                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = items[i].GetItem().itemName;
                if (items[i].GetItem().isStackable)
                    slots[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = items[i].GetQuantity() + "";
                else
                    slots[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "";

            }
            catch
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
                slots[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "";

            }

        }
    }


    public bool Add(ItemClass item)
    {
        SlotClass slot = Contains(item);
        if (slot != null && slot.GetItem().isStackable)
            slot.AddQuantity(1);
        else
        {
            if (items.Count < slots.Length)
                items.Add(new SlotClass(item, 1));
            else
                return false;
        }

        RefreshUI();
        return true;
    }

    public bool Remove(ItemClass item)
    {
        SlotClass temp = Contains(item);
        if (temp != null)
        {
            if (temp.GetQuantity() > 1)
                temp.SubQuantity(1);
            else
            {
                SlotClass slotToRemove = new SlotClass();

                foreach (SlotClass slot in items)
                {
                    if (slot.GetItem() == item)
                    {
                        slotToRemove = slot;
                        break;
                    }
                }
                items.Remove(slotToRemove);
            }
        }
        else
        {
            return false;
        }

        RefreshUI();
        return true;

    }

    public SlotClass Contains(ItemClass item)
    {
        foreach (SlotClass slot in items)
        {
            if (slot.GetItem() == item)
                return slot;
        }
        return null;
    }

    private void OnSlotClicked(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            ItemClass item = items[index].GetItem();
            if (item is SO_ConsumableClass consumableItem)
            {
                AddHeathPoints(consumableItem);
            }
            else if (item is SO_WeaponClass weaponItem)
            {
                EquipWeapon(weaponItem);
            }
            else
            {
                Debug.Log("Invalid item clicked.");
            }
        }
        else
        {
            Debug.LogWarning("Index out of range.");
        }
    }

    public void AddHeathPoints(SO_ConsumableClass item)
    {
        Remove(item);

        if (briarStats != null)
        {
            briarStats.AddHealth(item.GetHealthPoints());
            Debug.Log(string.Format("Player has recovered {0} health points", item.GetHealthPoints()));
        }
        else
        {
            Debug.LogError("SCR_BriarStats reference is not set!");
        }

        Debug.Log(string.Format("Player has recovered {0} health points", item.GetHealthPoints()));
        RefreshUI();
    }

    public void EquipWeapon(SO_WeaponClass item)
    {
        slotWeapon.transform.GetChild(0).GetComponent<Image>().enabled = true;
        slotWeapon.transform.GetChild(0).GetComponent<Image>().sprite = item.itemSprite;
        slotWeapon.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.itemName;
        RefreshUI();
    }

    public void LoadData(GameData data)
    {
        items.Clear();
        //Debug.Log("Loading Inventory");
        foreach (ItemData itemData in data.inventoryItems)
        {
            items.Add(new SlotClass(itemData.item, itemData.quantity));
        }
    }

    public void SaveData(GameData data)
    {
        data.inventoryItems.Clear();
        //Debug.Log("Saved Inventory");
        foreach (SlotClass slot in items)
        {
            data.inventoryItems.Add(new ItemData { item = slot.GetItem(), quantity = slot.GetQuantity() });
        }
    }

}
