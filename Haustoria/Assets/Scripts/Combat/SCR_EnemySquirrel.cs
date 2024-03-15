using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SCR_EnemySquirrel : MonoBehaviour
{

    [SerializeField] private GameObject CombatManager;

    [SerializeField] private SCROBJ_BRIAR_ATTACKS AttackValues;

    [SerializeField] private int health;



    [Header("Attack or Attacks")]
    [SerializeField] private GameObject Attack;

    [SerializeField] private GameObject player;

    private Animator anim;

    private SpriteRenderer spriterend;

    private GameObject HealthSlider;

    [SerializeField] private SpriteRenderer[] SpritesToDamage;

    




    private void Start()
    {
        spriterend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        HealthSlider = GameObject.Find("EnemyHealthSlider");
        player = GameObject.FindGameObjectWithTag("Player");

        HealthSlider.GetComponent<Slider>().maxValue = health;
        HealthSlider.GetComponent<Slider>().value = health;
    }

    public void EnemyAttack()
    {
     
        int AttackRNG = Random.Range(0, 1);


        switch (AttackRNG)
        {
            case 0:
                StartCoroutine(SquirrelattackOne());
                break;

        }



    }


    public IEnumerator SquirrelattackOne()
    {
       

        Attack.SetActive(true);


        yield return new WaitForSeconds(5f);

        Attack.SetActive(false);

        yield return new WaitForSeconds(0.5f);




        CombatManager.GetComponent<SCR_EnemySelect>().BriarTurn();


        yield return null;
    }
    public void takeDamage()
    {

        StartCoroutine(SquirrelDamage());

    }

    private IEnumerator SquirrelDamage()
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

