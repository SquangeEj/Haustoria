using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SCR_JournalQuestUpdater : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textext;
    void Start()
    {
       
    }

    private void Update()
    {
        textext = GetComponent<TextMeshProUGUI>();
        textext.text = DataPersistanceManager.instance.gameData.questDescription.ToString();
     
    }
    // Update is called once per frame
 
}
