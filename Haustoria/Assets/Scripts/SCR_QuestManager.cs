using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SCR_QuestManager : MonoBehaviour
{
    public int QuestID;
    private string QuestDescription;

    [SerializeField] private TextMeshProUGUI Text;
    private void Start()
    {
        QuestID = DataPersistanceManager.instance.gameData.questid;

        Text.text = QuestDescription = DataPersistanceManager.instance.gameData.questDescription;
    }

    public void SetQuestID(int NewID)
    {
    
        DataPersistanceManager.instance.gameData.questid = NewID;

    }

    public void SetQuestDescription(string Description)
    {
        DataPersistanceManager.instance.gameData.questDescription = Description;
        updatequest();
    }

    private void updatequest()
    {
        Text.text = QuestDescription = DataPersistanceManager.instance.gameData.questDescription;
    }


   
}
