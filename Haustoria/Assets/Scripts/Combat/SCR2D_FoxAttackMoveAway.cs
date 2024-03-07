using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR2D_FoxAttackMoveAway : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb2d;
    [SerializeField] private float speed;


    [SerializeField] private GameObject Thingtospawn;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(new Vector2(Random.Range(-5, 5f), Random.Range(-5, 5f) * speed/5) , ForceMode2D.Impulse);

        StartCoroutine(HurtTrail());
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.AddForce(((transform.position - player.transform.position).normalized * speed)*Time.deltaTime, ForceMode2D.Impulse);
    }

    private IEnumerator HurtTrail()
    {
        GameObject Spawnedthing = Instantiate(Thingtospawn, transform.position, Quaternion.identity);

        Destroy(Spawnedthing, 2f);
        yield return new WaitForSeconds(0.1f);

        StartCoroutine(HurtTrail());

        yield return null;
    }
}
