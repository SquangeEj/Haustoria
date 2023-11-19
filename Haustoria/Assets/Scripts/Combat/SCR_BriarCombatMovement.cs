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

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        combatmanager = GameObject.Find("CombatManager");
      
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
        combatmanager.GetComponent<SCR_EnemySelect>().StartCoroutine("ScreenShake");

        BriarHealth.Health -= Damage;
        BriarHealthText.text = BriarHealth.Health.ToString();
        switch (BriarHealth.Health)
        {
            case 10:
                BriarFace.sprite = BriarNeutral;
                break;

            case < 0:
                SceneManager.LoadScene(3);
                break;

            case < 5:
                BriarFace.sprite = BriarDying;
                break;

            case <10:
                BriarFace.sprite = BriarHurt;
                break;

           
        }
    }
}
