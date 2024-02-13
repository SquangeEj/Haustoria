using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_SkillTree : MonoBehaviour, IDataPersistance
{

    private int skillID;

    [SerializeField]
    private Button[] RootButtons;

    [SerializeField]
    private int RootPointsUnlocked;



   

    private void Awake()
    {
        for(int i=0; i<RootPointsUnlocked; i++)
        {
            RootButtons[i].interactable = true;
        }
    }

    public void RootSkillGotten()
    {
        RootPointsUnlocked += 1;
        for (int i = 0; i < RootPointsUnlocked; i++)
        {
            RootButtons[i].interactable = true;
        }
        gameObject.SetActive(false);

    }


    public void LoadData(GameData data)
    {
       
    }

    public void SaveData(GameData data)
    {
     
    }
}
