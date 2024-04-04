using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using FMODUnity;
using Cinemachine;
using TMPro;


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

    [SerializeField] private GameObject ComboNumber;


    [SerializeField] private StudioEventEmitter FmodEvent, FmodMiss;
    private int timeshit;

    private CinemachineImpulseSource imp;


  
    private void OnEnable()
    {
        resetSpeed();
        damage = basedamage;

        anim = GetComponent<Animator>();
        FmodEvent = GetComponent<StudioEventEmitter>();
        imp = GetComponent<CinemachineImpulseSource>();

        FmodEvent.SetParameter("Times Hit", 0);
        timeshit = 1;
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
            else
            {
                damage /= multiplier;
                StartCoroutine(GameFeelWrong());
            }

        }
    }

    private IEnumerator GameFeel()
    {
        FmodEvent.Play();
        
        FmodEvent.SetParameter("Times Hit", timeshit);
        imp.GenerateImpulse(timeshit);
       

        GameObject DamageNum = Instantiate(ComboNumber, transform.position, Quaternion.identity);
        DamageNum.GetComponent<TMP_Text>().text = timeshit.ToString();
        DamageNum.GetComponent<Rigidbody2D>().AddForce(new Vector2(UnityEngine.Random.Range(-5, 6), 8), ForceMode2D.Impulse);
        DamageNum.GetComponent<TMP_Text>().fontSizeMax = timeshit ;
        Destroy(DamageNum, 10f);

        timeshit += 1;


        for (float t = 0; t < 1; t += 4f * Time.deltaTime)
        {
            SquareSprite.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.green, Color.white, t);
            SquareSprite.transform.localScale = Vector3.Lerp(new Vector3(2, 2, 2), new Vector3(1, 1, 1), t);
            yield return null;
        }
        yield return null;
    }



    private IEnumerator GameFeelWrong()
    {
        FmodMiss.Play();
        
   

        for (float t = 0; t < 1; t += 4f * Time.deltaTime)
        {
            SquareSprite.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.red, Color.white, t);
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
        //imp.GenerateImpulse(damage/2);
        imp.GenerateImpulseWithVelocity(new Vector3(damage/10,damage/10,damage/10));
        AttackSCR.damagetaken = damagedealt;

        combatManager.GetComponent<SCR_EnemySelect>().DamageEnemy();
        combatManager.GetComponent<SCR_EnemySelect>().EnemyTurn();

        AttackAnimation.SetActive(true);


         this.gameObject.SetActive(false);
    }
}
