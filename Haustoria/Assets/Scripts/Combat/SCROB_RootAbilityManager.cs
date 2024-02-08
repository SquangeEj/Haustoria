using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SCROB_RootAbilityManager : MonoBehaviour,IDataPersistance
{
    
    public bool[] AbilitiesUnlocked;

    public void LoadData(GameData data)
    {
        Debug.Log("is here");

        AbilitiesUnlocked = data.AbilityID;

      
    }

    public void SaveData(GameData data)
    {
        

    }

}
