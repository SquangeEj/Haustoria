using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData 
{
    public int health;

    public Vector3 BriarPosition;

    public Dictionary<string, bool> AbiltiesUnlocked;

    public GameData()
    {
        AbiltiesUnlocked = new Dictionary<string, bool>();
    }
}
