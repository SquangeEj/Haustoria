using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SCR_EnemyHedgehog : MonoBehaviour
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

        HealthSlider.GetComponent<Slider>().maxValue = health;
        HealthSlider.GetComponent<Slider>().value = health;
    }

    public void EnemyAttack()
    {
        int AttackRNG = Random.Range(0, 1);


        switch (AttackRNG)
        {
            case 0:
                StartCoroutine(HedgehogattackOne());
                break;

            case 1:

                break;
        }



    }


    public IEnumerator HedgehogattackOne()
    {
        yield return new WaitForSeconds(1f);


        for (int i = 0; i < Random.Range(1,15); i++)
        {
            GameObject HedgehogBounce = Instantiate(Attack, player.transform.position + new Vector3(Random.Range(-2, 2f), Random.Range(-2, 2f), 0), Quaternion.identity);
            Destroy(HedgehogBounce, 8f);
           // yield return new WaitForSeconds(0.1f);
        }



        yield return new WaitForSeconds(10f);

        CombatManager.GetComponent<SCR_EnemySelect>().BriarTurn();


        yield return null;
    }



    public void takeDamage()
    {

        StartCoroutine(BearDamage());

    }

    private IEnumerator BearDamage()
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
