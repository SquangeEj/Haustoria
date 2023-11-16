using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_2dSimpleFollow : MonoBehaviour
{
    Rigidbody2D rb;

    GameObject Player;

    [SerializeField] private float Speed;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(((Player.transform.position - transform.position) * Speed) * Time.deltaTime, ForceMode2D.Impulse); ;
    }
}
