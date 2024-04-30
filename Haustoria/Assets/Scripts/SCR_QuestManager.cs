using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_QuestManager : MonoBehaviour
{
  

    public void SetQuestID(int NewID)
    {
        Debug.Log("Sure honestly");
        DataPersistanceManager.instance.gameData.questid = NewID;

    }


    public void SetQuestDescription(string Desc)
    {
       
        DataPersistanceManager.instance.gameData.questDescription = Desc;
      

    }

    public void Fart()
    {
        Debug.Log("WARTR");
    }

/*    private void updatequest()
    {
        Text.text = QuestDescription = DataPersistanceManager.instance.gameData.questDescription;
    }*/


   
}
