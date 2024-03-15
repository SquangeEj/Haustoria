using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SCR_EnemyRats : MonoBehaviour
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

    [SerializeField] private int CurrentAttack = 0;

    bool attacking;
    private BoxCollider2D ratbox;

    private void Start()
    {
        spriterend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        HealthSlider = GameObject.Find("EnemyHealthSlider");
        player = GameObject.FindGameObjectWithTag("Player");
        ratbox = GetComponent<BoxCollider2D>();

        HealthSlider.GetComponent<Slider>().maxValue = health;
        HealthSlider.GetComponent<Slider>().value = health;

    }

    public void EnemyAttack()
    {



        attacking = true;
        switch (CurrentAttack)
        {
            case 0:
                StartCoroutine(RatattackOne());
                break;
            case 1:
                StartCoroutine(RatattackTwo());
                break;
            case 2:
                StartCoroutine(RatattackThree());
                break;
            case 3:
                StartCoroutine(RatattackFour());
                break;


        }

        CurrentAttack += 1;
        if (CurrentAttack >= 4)
        {
            CurrentAttack = 3;
        }

    }

    
    public IEnumerator RatattackOne()
    {
        yield return new WaitForSeconds(0);

        anim.Play("RatAttack1");
       

        yield return new WaitForSeconds(5f);
        anim.Play("RatIdle");
        CombatManager.GetComponent<SCR_EnemySelect>().BriarTurn();
        attacking = false;

        yield return null;
    }

    public IEnumerator RatattackTwo()
    {
        yield return new WaitForSeconds(0);

        anim.Play("RatAttack2");


        yield return new WaitForSeconds(5f);
        anim.Play("RatIdle");
        CombatManager.GetComponent<SCR_EnemySelect>().BriarTurn();
        attacking = false;

        yield return null;
    }


    public IEnumerator RatattackThree()
    {
        yield return new WaitForSeconds(0);

        anim.Play("RatAttack3");


        yield return new WaitForSeconds(5f);
        anim.Play("RatIdle");
        CombatManager.GetComponent<SCR_EnemySelect>().BriarTurn();

        attacking = false;
        yield return null;
    }


    public IEnumerator RatattackFour()
    {
        yield return new WaitForSeconds(0);

        anim.Play("RatAttack4");


        yield return new WaitForSeconds(5f);
        anim.Play("RatIdle");
        CombatManager.GetComponent<SCR_EnemySelect>().BriarTurn();
        attacking = false;

        yield return null;
    }





    public void takeDamage()
    {

        StartCoroutine(RatsDamage());

    }

    private IEnumerator RatsDamage()
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

