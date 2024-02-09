using System.Collections;
using UnityEngine;

public abstract class ItemClass : ScriptableObject
{
    
    public Sprite itemIcon;
    public string itemName;
    public bool isStackable = true;
    public bool isEquipable = false;
    public GameObject prefab;

    public abstract ItemClass GetItem();
    public abstract EquipmentClass GetEquipment();
    public abstract ConsumableClass GetConsumable();
    public abstract MiscClass GetMisc();
}
