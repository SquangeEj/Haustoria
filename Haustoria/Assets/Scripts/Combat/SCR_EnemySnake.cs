using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SCR_EnemySnake : MonoBehaviour
{

    [SerializeField] private GameObject CombatManager;

    [SerializeField] private SCROBJ_BRIAR_ATTACKS AttackValues;

    [SerializeField] private int health;

    [SerializeField] private Transform[] Positions;



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
        int AttackRNG = Random.Range(0, 2);


        switch (AttackRNG)
        {
            case 0:
                StartCoroutine(SnakeattackOne());
                break;

            case 1:
                StartCoroutine(SnakeattackTwo());
                break;
        }



    }


    public IEnumerator SnakeattackOne()
    {
        yield return new WaitForSeconds(1f);


        anim.Play("SnakeAttackOne");
        yield return new WaitForSeconds(0.2f);

        for (int i = 0; i < 100; i++)
        {
            
                GameObject venomdrop = Instantiate(Attack, Positions[Random.Range(0,2)].position, Quaternion.identity);
                Destroy(venomdrop, 3f);
                
            yield return new WaitForSeconds(Random.Range(0f,0.2f));

        }


        yield return new WaitForSeconds(0.5f);
        anim.Play("SnakeAttackOver");

        CombatManager.GetComponent<SCR_EnemySelect>().BriarTurn();


        yield return null;
    }

    public IEnumerator SnakeattackTwo()
    {
        yield return new WaitForSeconds(1f);


        anim.Play("SnakeAttackOne");
        yield return new WaitForSeconds(0.2f);

        for (int i = 0; i < 100; i++)
        {

            GameObject venomdrop = Instantiate(Attack, Positions[Random.Range(0, 2)].position, Quaternion.identity);
            Destroy(venomdrop, 3f);
            venomdrop.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-2, 2), 0), ForceMode2D.Impulse);

            yield return new WaitForSeconds(Random.Range(0f, 0.2f));

        }


        yield return new WaitForSeconds(0.5f);
        anim.Play("SnakeAttackOver");

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
