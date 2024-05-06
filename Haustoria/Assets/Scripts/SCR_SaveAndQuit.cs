using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_SaveAndQuit : MonoBehaviour, IDataPersistance
{
    
    void Start()
    {
        
    }

    public void LoadData(GameData data)
    {

    }
    public void SaveData(GameData data)
    {
        
    }

    public void Quit()
    {
        SaveData(DataPersistanceManager.instance.gameData);
        StartCoroutine(SaveAndQuit());
    }
    private IEnumerator SaveAndQuit()
    {

        DataPersistanceManager.instance.SaveGame();

        yield return new WaitForSeconds(3f);
        Application.Quit();


        yield return null;
    }
}
