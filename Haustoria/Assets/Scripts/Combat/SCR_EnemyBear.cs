using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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


    private void Start()
    {
        spriterend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    public void EnemyAttack()
    {
        StartCoroutine(Bearattack());
    }


    public IEnumerator Bearattack()
    {
        anim.Play("BearAttackTwo");
   


       
        yield return new WaitForSeconds(5f);

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
        for (float t = 0; t < 1; t += 1f * Time.deltaTime)
        {
            spriterend.color = Color.Lerp(Color.red, Color.white, t);
          
            yield return null;
        }

        health -= AttackValues.damagetaken;
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
        yield return null;
    }
}
