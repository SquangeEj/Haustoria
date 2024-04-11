using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SCR_StatsUI : MonoBehaviour
{
    public TMP_Text healthText;
    public TMP_Text atkText;
    public TMP_Text defText;
    public TMP_Text xpText;
    public TMP_Text AbilityText;

    SCR_BriarStats briarStats;

    void Start()
    {
        
        GameObject briar = GameObject.Find("Briar");
        briarStats  = briar.GetComponent<SCR_BriarStats>();
        
        UpdateUI();
    }

    void UpdateUI()
    {
        healthText.text = "Health: " + briarStats.Health.ToString();
        atkText.text = "Attack: " + briarStats.Attack.ToString();
        defText.text = "Defense: " + briarStats.Defence.ToString();
        xpText.text = "Experience: " + briarStats.XP.ToString();
        AbilityText.text = "Ability Points: " + briarStats.AbilityPoints.ToString();
    }

    // Call this method whenever stats are updated
    public void UpdateStatsUI()
    {
        UpdateUI();
    }
}