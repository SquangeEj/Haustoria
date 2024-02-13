using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_CameraToAnimate : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.Play("Play");
        }
    }






    private void DeleteThis()
    {
        Destroy(this.gameObject);
    }
}
