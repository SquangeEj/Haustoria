using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SCR_BriarCombatMovement : MonoBehaviour
{
    [SerializeField] private SCROBJ_BRIAR_STATS BriarHealth;

    public float MoveSpeed;

    private Rigidbody2D rb2d;

    [SerializeField]
    private Image BriarFace;

    [SerializeField]
    private Sprite BriarNeutral, BriarHurt, BriarDying;

    private GameObject combatmanager;

    [SerializeField]
    private TMP_Text BriarHealthText;

    private int Defence;

    

    private void Start()
    {
       
        rb2d = GetComponent<Rigidbody2D>();
        combatmanager = GameObject.Find("CombatManager");
        Defence = DataPersistanceManager.instance.gameData.Def;
      
    }
 
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0);

        if (Input.GetKeyDown(KeyCode.Space))
        {

        }

        rb2d.AddForce((move * MoveSpeed) * Time.deltaTime, ForceMode2D.Impulse);

      //  transform.position += (move * MoveSpeed) * Time.deltaTime;
    }


    public void TakeDamage(int Damage)
    {

        StartCoroutine(TakeDamageInum(Damage));
    }

    private IEnumerator TakeDamageInum(int Dam)
    {
        combatmanager.GetComponent<SCR_EnemySelect>().StartCoroutine("ScreenShake");

        Dam -= Defence;
        BriarHealth.Health -= Dam;
        BriarHealthText.text = BriarHealth.Health.ToString();

        for (float i = 0; i < 1; i += 5 * Time.deltaTime)
        {
            BriarFace.sprite = BriarFace.sprite = BriarHurt;
            yield return null;
        }

        switch (BriarHealth.Health)
        {
            case > 50:
                BriarFace.sprite = BriarNeutral;
                break;

            case < 0:
                SceneManager.LoadScene(3);
                break;



            case < 50:
                BriarFace.sprite = BriarDying;
                break;


        }
        yield return null;
    }

    public void RecoverHealth(int amount)
    {
        StartCoroutine(RecoverHealthCoroutine(amount));
    }

    private IEnumerator RecoverHealthCoroutine(int amount)
    {
        BriarHealth.Health += amount;
        BriarHealth.Health = Mathf.Min(BriarHealth.Health, BriarHealth.MaxHealth);

        // Update the health text
        BriarHealthText.text = BriarHealth.Health.ToString();


        yield return null; // Yield null to end the coroutine
    }
}
