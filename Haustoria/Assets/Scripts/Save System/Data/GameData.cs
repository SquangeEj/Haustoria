using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public int health, stamina;

    public int Xp, Atk, Def;

    public int questid;

    public int SceneId;

    public Vector3 BriarPosition;

    //   public Dictionary<int, bool> AbiltiesUnlocked = new Dictionary<int, bool>();
    // dictionary didnt work



    public bool[] SkillID = new bool[3];

    public int RootAbilityPointsUsed;


    public bool[] AbilityID = new bool[3];

    public Dictionary<GameObject, bool> EnemiesDead;

    public List<ItemData> inventoryItems = new List<ItemData>();

}

[System.Serializable]
public class ItemData
{
    public ItemClass item;
    public int quantity;
}
