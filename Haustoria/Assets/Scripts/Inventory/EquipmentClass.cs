using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Item Class", menuName = "Item/Equipment")]

public class EquipmentClass : ItemClass
{
    public float baseDamage;  //Use this float to change weapon damages
    public override ItemClass GetItem() { return this; }
    public override ConsumableClass GetConsumable() { return null; }
    public override MiscClass GetMisc() { return null; }
    public override EquipmentClass GetEquipment() { return this; }

}