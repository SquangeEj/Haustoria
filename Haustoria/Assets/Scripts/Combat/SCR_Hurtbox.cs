using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Hurtbox : MonoBehaviour
{
    [SerializeField]
    private int damage;

    [SerializeField] private bool Destroyafter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<SCR_BriarCombatMovement>().TakeDamage(damage);

            if (Destroyafter == true)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void simpledestroy()
    {
        Destroy(this.gameObject);
    }
}
