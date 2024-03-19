using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_QuestManager : MonoBehaviour, IDataPersistance
{
    public int QuestID;

    public void LoadData(GameData data)
    {
        QuestID = data.questid;
    }

    public void SetQuestID(int NewID)
    {
        QuestID = NewID;


    }

    public void SaveData(GameData data)
    {
        data.questid = QuestID;
    }
}
