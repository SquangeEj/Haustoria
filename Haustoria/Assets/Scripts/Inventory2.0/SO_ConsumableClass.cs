using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Items/Consumables")]

public class SO_ConsumableClass : ItemClass
{
    [SerializeField] private int healthPoints;

    public int GetHealthPoints()
    {
        return healthPoints;
    }
}
