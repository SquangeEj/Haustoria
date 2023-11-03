using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_BriarCombatMovement : MonoBehaviour
{
    public float MoveSpeed;

    private Rigidbody2D rb2d;

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
}
