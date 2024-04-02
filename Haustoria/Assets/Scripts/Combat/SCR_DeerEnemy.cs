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
    [SerializeField] private GameObject Attack, Attack2;

    [SerializeField] private GameObject player;

    [SerializeField] private Animator antleranim;

    [SerializeField] private Vector3[] Headattackside;

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
        int AttackRNG = Random.Range(0, 4);


        switch (AttackRNG)
        {
            case 0:
                StartCoroutine(DeerattackOne());
                break;

            case 1:
                StartCoroutine(DeerattackTwo());
                break;

            case 2:
                StartCoroutine(DeerattackThree());
                break;
            case 3:
                StartCoroutine(DeerattackFour());
                break;
        }



    }


    public IEnumerator DeerattackOne()
    {
        yield return new WaitForSeconds(1f);

        antleranim.Play("AntlerAttackLeft");



        yield return new WaitForSeconds(3f);

        antleranim.Play("Idle");
        CombatManager.GetComponent<SCR_EnemySelect>().BriarTurn();


        yield return null;
    }
    public IEnumerator DeerattackTwo()
    {
        yield return new WaitForSeconds(1f);



        antleranim.Play("AntlerAttackRight");

        yield return new WaitForSeconds(3f);

        antleranim.Play("Idle");

        CombatManager.GetComponent<SCR_EnemySelect>().BriarTurn();


        yield return null;
    }

    public IEnumerator DeerattackThree()
    {
        yield return new WaitForSeconds(1f);
        
        
        

        for(int i = 0; i < Random.Range(1, 5f); i++)
        {
            var side = Random.Range(0, 2);
            GameObject AntlerAttack = Instantiate(Attack, Headattackside[side], Quaternion.identity);
            if(side == 1)
            {
                AntlerAttack.transform.eulerAngles = new Vector3(0, 180, 0);
            }
            Destroy(AntlerAttack, 3f);
             yield return new WaitForSeconds(Random.Range(1f,2f));
        }

        

        yield return new WaitForSeconds(3f);

        antleranim.Play("Idle");

        CombatManager.GetComponent<SCR_EnemySelect>().BriarTurn();


        yield return null;
    }

    public IEnumerator DeerattackFour()
    {
        yield return new WaitForSeconds(1f);



        GameObject attack2 = Instantiate(Attack2, transform.position - new Vector3(0,4f,0), Quaternion.identity);

        Destroy(attack2, 10f);
      


        yield return new WaitForSeconds(8f);

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
