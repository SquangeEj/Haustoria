using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using TMPro;
using Cinemachine;
using UnityEngine.SceneManagement;

public class SCR_EnemySelect : MonoBehaviour
{     

    [Header("Data storage (VERY IMPORTANT)")]
    [SerializeField] private SCROBJ_CombatStartManager CombatData;

    [SerializeField] private SCROBJ_BRIAR_STATS BriarStats;

    [SerializeField] private SCROBJ_BRIAR_ATTACKS AttackValues;

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


    [SerializeField] private GameObject DamageNumber;



    [SerializeField]
    private TMP_Text BriarHealthText;

    private int previousSceneIndex;

    void Start()
    {
        BriarHealthText.text = BriarStats.Health.ToString();

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

        previousSceneIndex = SceneManager.GetActiveScene().buildIndex;

        StartCoroutine(StartCombat());
    }


    IEnumerator StartCombat()
    {
     
        //this is the transparency intro, however, just gonna animate that instead, its easier :D 

     /*   for (float t = 0; t < 1; t+= 0.005f)
        {
            CurrentEnemy.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.clear, Color.white, t);
            yield return null;
        }*/
        yield return null;

      
        
    }

    public void EnemyDied()
    {
        StartCoroutine(EndCombat());
    }

    IEnumerator EndCombat()
    {
        if(CombatData.EnemyID == 1)
        {
            SceneManager.LoadScene(4);
        }
        SceneManager.LoadScene(4);
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


        GameObject DamageNum = Instantiate(DamageNumber, transform.position, Quaternion.identity);
        DamageNum.GetComponent<TMP_Text>().text = AttackValues.damagetaken.ToString();
        DamageNum.GetComponent<Rigidbody2D>().AddForce(new Vector2(UnityEngine.Random.Range(-5,6), 8), ForceMode2D.Impulse);
        DamageNum.GetComponent<TMP_Text>().fontSizeMax = (AttackValues.damagetaken/10 )+1;
        Destroy(DamageNum, 10f);
        StartCoroutine(ScreenShake());
    }

    public IEnumerator ScreenShake()
    {
        
        for (float i = 1; i > 0; i-=4 * Time.deltaTime)
        {
            BriarCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = i * AttackValues.damagetaken/10;
            yield return null;
        }
        BriarCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
        yield return null;
    }

   
  
}
