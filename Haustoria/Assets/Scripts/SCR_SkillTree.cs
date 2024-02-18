using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_SkillTree : MonoBehaviour
{

    private int skillID;

    [SerializeField]
    private Button[] RootButtons;

    [SerializeField]
    private int RootPointsUnlocked;



   

    private void Awake()
    {
        Debug.Log("AWAKE");
        GameObject briar = GameObject.Find("Briar");
        RootPointsUnlocked = briar.GetComponent<SCR_BriarStats>().RootAbilityPointsSpent;

        for(int i=0; i<=RootPointsUnlocked; i++)
        {
            RootButtons[i].interactable = true;
         
        }
        for (int i = 0; i <= RootPointsUnlocked; i++)
        {

            if (i != 0)
            {
                RootButtons[i - 1].interactable = false;
                RootButtons[i - 1].GetComponent<Image>().color = Color.green;
                Debug.Log(RootButtons[i - 1]);
                
            }
         
        }
      

    }

    public void RootSkillGotten()
    {
        GameObject briar = GameObject.Find("Briar");

        RootPointsUnlocked += 1;

        for (int i = 0; i <= RootPointsUnlocked; i++)
        {
            RootButtons[i].interactable = true;

        }
        for (int i = 0; i <= RootPointsUnlocked; i++)
        {

            if (i != 0)
            {
                RootButtons[i - 1].interactable = false;
                RootButtons[i - 1].GetComponent<Image>().color = Color.green;
                Debug.Log(RootButtons[i - 1]);

            }

        }


        briar.GetComponent<SCR_BriarStats>().RootAbilityPointsSpent  =   RootPointsUnlocked;
        gameObject.SetActive(false);

    }



}
