using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_HedgehogBall : MonoBehaviour
{
    [SerializeField]
    private GameObject quill;

    private void AddRandomForce()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        //GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-5, 5), Random.Range(-5, 5)),ForceMode2D.Impulse);

         GetComponent<Rigidbody2D>().AddForce( (player.transform.position- transform.position).normalized * 3, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        for (int i = 0; i<=360; i += 90)
        {
            GameObject Quill = Instantiate(quill, transform.position, Quaternion.Euler(0,0,i));
            Destroy(Quill, 4f);
        }
    }
}
