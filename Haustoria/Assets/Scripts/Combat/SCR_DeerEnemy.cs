using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SCR_DeerEnemy : MonoBehaviour
{

    [SerializeField] private GameObject CombatManager;

    [SerializeField] private SCROBJ_BRIAR_ATTACKS AttackValues;

    [SerializeField] private int health;



    
    [Header("Attack or Attacks")]
    [SerializeField] private GameObject Attack;

    [SerializeField] private GameObject player;

    [SerializeField] private Animator antleranim;

    private Animator anim;

    private SpriteRenderer spriterend;

    private GameObject HealthSlider;

    [SerializeField] private SpriteRenderer[] SpritesToDamage;




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
        int AttackRNG = Random.Range(0, 2);


        switch (AttackRNG)
        {
            case 0:
                StartCoroutine(DeerattackOne());
                break;

            case 1:
                StartCoroutine(DeerattackTwo());
                break;
        }



    }


    public IEnumerator DeerattackOne()
    {
        yield return new WaitForSeconds(1f);

        antleranim.Play("AntlerAttackLeft");



        yield return new WaitForSeconds(2.5f);

        antleranim.Play("Idle");
        CombatManager.GetComponent<SCR_EnemySelect>().BriarTurn();


        yield return null;
    }
    public IEnumerator DeerattackTwo()
    {
        yield return new WaitForSeconds(1f);



        antleranim.Play("AntlerAttackRight");

        yield return new WaitForSeconds(2.5f);

        antleranim.Play("Idle");

        CombatManager.GetComponent<SCR_EnemySelect>().BriarTurn();


        yield return null;
    }


    public void takeDamage()
    {

        StartCoroutine(DeerDamage());

    }

    private IEnumerator DeerDamage()
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
