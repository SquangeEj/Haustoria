using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using TMPro;
using Cinemachine;

public class SCR_EnemySelect : MonoBehaviour
{     

    [Header("Data storage (VERY IMPORTANT)")]
    [SerializeField] private SCROBJ_CombatStartManager CombatData;

    [Header("List of enemies, make sure IDs are correct")]
    [SerializeField] private GameObject[] Enemies;

    [Header("List of backgrounds, still make sure IDs are correct")]
    [SerializeField] private GameObject[] Backgrounds;


    [SerializeField] private GameObject CurrentEnemy; // this is to refer to the enemies attacks and stuff
   

    [SerializeField] private TextMeshProUGUI EnemyName_TXT;

    [SerializeField] private GameObject BriarTurnUI;
    [SerializeField] private GameObject BriarCombatGameplay;

    [SerializeField] private CinemachineVirtualCamera BriarCamera;

   
    void Start()
    {
       
        foreach (GameObject enemy in Enemies)
        {

            enemy.SetActive(false);
            
        }


        foreach (GameObject Background in Backgrounds)
        {

            Background.SetActive(false);

        }

        Enemies[CombatData.EnemyID].SetActive(true);
        Backgrounds[CombatData.BackgroundID].SetActive(true);
        EnemyName_TXT.text = CombatData.EnemyNames[CombatData.EnemyID];
        CurrentEnemy = Enemies[CombatData.EnemyID];

        StartCoroutine(StartCombat());
    }


    IEnumerator StartCombat()
    {
     
        for (float t = 0; t < 1; t+= 0.005f)
        {
            CurrentEnemy.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.clear, Color.white, t);
            yield return null;
        }
        yield return null;


        
    }

    IEnumerator EndCombat()
    {
        yield return null;
    }


    public void BriarTurn()
    {
        StartCoroutine(BriarTurnStart());
    }

     IEnumerator BriarTurnStart()
    {
        BriarCombatGameplay.SetActive(false);
        BriarTurnUI.SetActive(true);
        yield return null;
    }


    public void EnemyTurn()
    {
        StartCoroutine(EnemyTurnStart());
    }

     IEnumerator EnemyTurnStart()
    {
        BriarCombatGameplay.SetActive(true);
        CurrentEnemy.GetComponent<SCR_EnemyAttackManager>().InvokeEvent();
        yield return null;
    }


    public void DamageEnemy()
    {

        CurrentEnemy.GetComponent<SCR_EnemyAttackManager>().OnDamageEnemy();

        StartCoroutine(ScreenShake());
    }

    private IEnumerator ScreenShake()
    {
        Debug.Log("wawa");
        for (float i = 1; i > 0; i-=4 * Time.deltaTime)
        {
            BriarCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = i;
            yield return null;
        }
        BriarCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
        yield return null;
    }

   
  
}
