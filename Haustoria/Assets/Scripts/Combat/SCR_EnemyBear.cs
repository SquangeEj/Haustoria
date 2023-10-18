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


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void EnemyAttack()
    {
        StartCoroutine(Bearattack());
    }


    public IEnumerator Bearattack()
    {
        anim.Play("BearAttackTwo");
     /*   for (int i = -10; i < 10; i += 2)
        {
            GameObject Claw = Instantiate(Attack, new Vector3(i, 0, 0), Quaternion.identity);
            for (float t = 0; t < 1; t += 20f * Time.deltaTime)
            {
                Claw.transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(0.5f, 0.5f, 0.5f), t);
          
                yield return null;
            }

           

            Claw.GetComponent<Rigidbody2D>().AddForce((Vector2.down * 1), ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.2f);
            Destroy(Claw, 4f);
        }
*/



       
        yield return new WaitForSeconds(5f);

        CombatManager.GetComponent<SCR_EnemySelect>().BriarTurn();

        anim.Play("BearIdle");

        yield return null;
    }

    public void takeDamage()
    {
        health -= AttackValues.damagetaken;
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
        Debug.Log(health);
    }
}
