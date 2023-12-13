using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SCR_EnemyBear : MonoBehaviour
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
        int AttackRNG = Random.Range(0, 1 + 1);


        switch (AttackRNG)
        {
            case 0:
                StartCoroutine(BearattackOne());
                break;

            case 1:
                StartCoroutine(BearattackTwo());
                break;
        }
    


    }


    public IEnumerator BearattackOne()
    {
        yield return new WaitForSeconds(1f);
        anim.Play("BearAttackOne");
   


       
        yield return new WaitForSeconds(6f);

        CombatManager.GetComponent<SCR_EnemySelect>().BriarTurn();

        anim.Play("BearIdle");

        yield return null;
    }

    public IEnumerator BearattackTwo()
    {
        yield return new WaitForSeconds(1f);

        GameObject ClawFollow = Instantiate(Attack, transform.position + new Vector3(-7.5f, 0, 0), Quaternion.identity);
        GameObject ClawFollow2 = Instantiate(Attack, transform.position + new Vector3(+7.5f, 0, 0), Quaternion.identity);


        for (float i = 0; i < 1; i += 1 * Time.deltaTime)
        {
            ClawFollow.transform.localScale = new Vector3(i, i, i);
            ClawFollow2.transform.localScale = new Vector3(i, i, i);
            yield return null;
        }

        yield return new WaitForSeconds(10f);
        for(float i =1; i>0; i -= 1 * Time.deltaTime)
        {
            ClawFollow.transform.localScale = new Vector3(i, i, i);
            ClawFollow2.transform.localScale = new Vector3(i, i, i);
            yield return null;
        }
        Destroy(ClawFollow);
        Destroy(ClawFollow2);




        yield return new WaitForSeconds(1f);

        CombatManager.GetComponent<SCR_EnemySelect>().BriarTurn();

        anim.Play("BearIdle");

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

            HealthSlider.GetComponent<Slider>().value = Mathf.Lerp(prevhealth, health, t*5);
           
            foreach(SpriteRenderer sprite in SpritesToDamage)
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
