using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class SCR_EnemyFox : MonoBehaviour
{

    [SerializeField] private GameObject CombatManager;

    [SerializeField] private SCROBJ_BRIAR_ATTACKS AttackValues;

    [SerializeField] private int health;

    [SerializeField] private TextMeshProUGUI text;
    

    [Header("Attack or Attacks")]
    [SerializeField] private GameObject Attack, AttackAnnoying, AttackVeryAnnoying;

    [SerializeField] private GameObject player;

    private Animator anim;

    private SpriteRenderer spriterend;

    private GameObject HealthSlider;

    [SerializeField] private SpriteRenderer[] SpritesToDamage;

    [SerializeField] private List<GameObject> FoxBalls;




    private void Start()
    {
        spriterend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        HealthSlider = GameObject.Find("EnemyHealthSlider");
        

        HealthSlider.GetComponent<Slider>().maxValue = health;
        HealthSlider.GetComponent<Slider>().value = health;
    }

    public void EnemyAttack()
    {
        FoxBalls.Clear();
        int AttackRNG = Random.Range(0, 3);


        switch (AttackRNG)
        {
            case 0:
                StartCoroutine(FoxattackOne());
                break;

            case 1:
                StartCoroutine(FoxattackTwo());
                break;
            case 2:
                StartCoroutine(FoxattackThree());
                break;
        }



    }


    public IEnumerator FoxattackOne()
    {
        yield return new WaitForSeconds(1f);

        text.text = "Grab them";
        for (float i = 0; i < 20; i+=10)
        {
            for (float z = 0; z < 6; z+=3f)
            {

                GameObject FoxBallStatic = Instantiate(Attack, new Vector3(-5 + i , -1.5f - z, 0), Quaternion.identity);


                FoxBalls.Add(FoxBallStatic);


                yield return new WaitForSeconds(0.15f);
            }



        }


        yield return new WaitForSeconds(3f);
    

        foreach(GameObject ball in FoxBalls)
        {
            if (ball != null)
            {
                player.GetComponent<SCR_BriarCombatMovement>().TakeDamage(10);
                Destroy(ball);
            }
        }
        text.text = "";
        FoxBalls.Clear();
        yield return new WaitForSeconds(0.2f);
        CombatManager.GetComponent<SCR_EnemySelect>().BriarTurn();


        yield return null;
    }

    public IEnumerator FoxattackTwo()
    {
        yield return new WaitForSeconds(1f);

        text.text = "Catch them";
        for (float i = 0; i <= 5; i += 5)
        {
           
                GameObject FoxBallAnnoying = Instantiate(AttackAnnoying, new Vector3(-2.5f + i, -2.5f , 0), Quaternion.identity);


                FoxBalls.Add(FoxBallAnnoying);


                yield return new WaitForSeconds(0.15f);
          



        }


        yield return new WaitForSeconds(4f);
        text.text = "";

        foreach (GameObject ball in FoxBalls)
        {
            if (ball != null)
            {
                player.GetComponent<SCR_BriarCombatMovement>().TakeDamage(15);
                Destroy(ball);
            }
        }
        FoxBalls.Clear();
        yield return new WaitForSeconds(0.2f);
        CombatManager.GetComponent<SCR_EnemySelect>().BriarTurn();


        yield return null;
    }

    public IEnumerator FoxattackThree()
    {
        yield return new WaitForSeconds(1f);

        text.text = "Grab it and avoid";

        GameObject FoxBallAnnoying = Instantiate(AttackVeryAnnoying, new Vector3(Random.Range(-2.5f,2.5f), -2.5f, 0), Quaternion.identity);


            FoxBalls.Add(FoxBallAnnoying);





        yield return new WaitForSeconds(8f);


        foreach (GameObject ball in FoxBalls)
        {
            if (ball != null)
            {
                player.GetComponent<SCR_BriarCombatMovement>().TakeDamage(30);
                Destroy(ball);
            }
        }
        text.text = "";
        FoxBalls.Clear();
        yield return new WaitForSeconds(0.2f);
        CombatManager.GetComponent<SCR_EnemySelect>().BriarTurn();


        yield return null;
    }



    public void takeDamage()
    {

        StartCoroutine(FoxDamage());

    }

    private IEnumerator FoxDamage()
    {
        var prevhealth = health;
        health -= AttackValues.damagetaken;

        for (float t = 0; t < 1; t += 1f * Time.deltaTime)
        {

            HealthSlider.GetComponent<Slider>().value = Mathf.Lerp(prevhealth, health, t * 5);

            foreach (SpriteRenderer sprite in SpritesToDamage)
            {
                sprite.color = Color.Lerp(Color.red, Color.white, t);
            }
            yield return null;
        }


        if (health <= 0)
        {
            CombatManager.GetComponent<SCR_EnemySelect>().EnemyDied();
            gameObject.SetActive(false);
        }
        yield return null;
    }
}

