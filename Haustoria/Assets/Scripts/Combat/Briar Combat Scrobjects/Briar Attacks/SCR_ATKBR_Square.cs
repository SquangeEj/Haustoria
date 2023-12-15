using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_ATKBR_Square : MonoBehaviour
{
    [Header("This is also necessary for it to deal damage")]
    [SerializeField] private SCROBJ_BRIAR_ATTACKS AttackSCR;

    [Header("Combat Manager (as usual)")]
    [SerializeField] private GameObject combatManager;

    [SerializeField] private GameObject AttackAnimation; // Check if each are unique or not

   private bool InArea;

    [Header("This is the amount of base damage it deals and the multiplier for when you hit")]
    [SerializeField] private float basedamage;
   [SerializeField]  private float damage;
   [SerializeField]  private float multiplier;
    [SerializeField] private float AnimSpeed;

    [SerializeField] private GameObject SquareSprite;

    [SerializeField] private Animator anim;

    


    private void Start()
    {
        anim = GetComponent<Animator>();

    }

    private void OnEnable()
    {
        damage = basedamage;
    }

    private void EnterZone()
   {
        InArea = true;
   }

    private void resetSpeed()
    {
        anim.speed = 1;
    }




    private void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
        {

            if (InArea == true)
            {
                InArea = false;
                damage *= multiplier;

                anim.speed = anim.speed * AnimSpeed;

                StartCoroutine(GameFeel());
            }

        }
    }

    private IEnumerator GameFeel()
    {

        for (float t = 0; t < 1; t += 4f * Time.deltaTime)
        {
            SquareSprite.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.green, Color.white, t);
            SquareSprite.transform.localScale = Vector3.Lerp(new Vector3(2, 2, 2), new Vector3(1, 1, 1), t);
            yield return null;
        }
        yield return null;
    }

    private void LeaveZone()
    {

    InArea = false;
        
    }

    private void FinishAttack()
    {
        int damagedealt = (int)damage;

        AttackSCR.damagetaken = damagedealt;

        combatManager.GetComponent<SCR_EnemySelect>().DamageEnemy();
        combatManager.GetComponent<SCR_EnemySelect>().EnemyTurn();

        AttackAnimation.SetActive(true);


         this.gameObject.SetActive(false);
    }
}
