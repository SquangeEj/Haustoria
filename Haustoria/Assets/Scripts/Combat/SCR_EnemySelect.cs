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

    [SerializeField] private SCROBJ_BRIAR_STATS BriarStats;

    [Header("List of enemies, make sure IDs are correct")]
    [SerializeField] private GameObject[] Enemies;

    [Header("List of backgrounds, still make sure IDs are correct")]
    [SerializeField] private GameObject[] Backgrounds;


    [SerializeField] private GameObject CurrentEnemy; // this is to refer to the enemies attacks and stuff
   

    [SerializeField] private TextMeshProUGUI EnemyName_TXT;

    [SerializeField] private GameObject BriarTurnUI;
    [SerializeField] private GameObject BriarCombatGameplay;

    [SerializeField] private CinemachineVirtualCamera BriarCamera;

    [SerializeField] private GameObject BriarHeart;





   
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
        yield return new WaitForSeconds(0.5f);
        BriarCombatGameplay.SetActive(true);
        BriarHeart.transform.position = new Vector3(0, -3.59f, 0);
        CurrentEnemy.GetComponent<SCR_EnemyAttackManager>().InvokeEvent();
        yield return null;
    }


    public void DamageEnemy()
    {

        CurrentEnemy.GetComponent<SCR_EnemyAttackManager>().OnDamageEnemy();

        StartCoroutine(ScreenShake());
    }

    public IEnumerator ScreenShake()
    {
        
        for (float i = 1; i > 0; i-=4 * Time.deltaTime)
        {
            BriarCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = i;
            yield return null;
        }
        BriarCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
        yield return null;
    }

   
  
}
