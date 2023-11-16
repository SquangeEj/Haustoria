using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_BriarCombatMovement : MonoBehaviour
{
    [SerializeField] private SCROBJ_BRIAR_STATS BriarHealth;

    public float MoveSpeed;

    private Rigidbody2D rb2d;

    [SerializeField]
    private Image BriarFace;

    [SerializeField]
    private Sprite BriarNeutral, BriarHurt, BriarDying;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
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
        BriarHealth.Health -= Damage;
        switch (BriarHealth.Health)
        {
            case 10:
                BriarFace.sprite = BriarNeutral;
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
