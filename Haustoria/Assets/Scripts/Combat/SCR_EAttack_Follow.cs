using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_EAttack_Follow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        rb2d.AddForce((player.transform.position - transform.position) * Time.deltaTime, ForceMode2D.Force);     ;

        /*     Vector3 diff = player.transform.position - transform.position;
             diff.Normalize();

             float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
             transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);*/

        Vector2 moveDirection = rb2d.velocity;
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x ) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
