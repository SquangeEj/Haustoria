using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Items/Weapons")]

public class SO_WeaponClass : ItemClass
{
    [SerializeField] private int baseDamage;

    //Add a function to EquipWeapon

    //Add function to Share Damage Int
    public int GetWeaponDamage()
    {
        return baseDamage;
    }
}
