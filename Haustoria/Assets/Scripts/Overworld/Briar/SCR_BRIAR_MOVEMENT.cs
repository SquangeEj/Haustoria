using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_BRIAR_MOVEMENT : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;

    private CharacterController controller;
    
    private Animator animator;

    private Vector3 playerVelocity;
 
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * moveSpeed);

        animator.SetFloat("Xmove", Input.GetAxis("Horizontal"));
        animator.SetFloat("Ymove", Input.GetAxis("Vertical"));

        /* if (move != Vector3.zero)
         {
             gameObject.transform.forward = move;
         }

         controller.SimpleMove(playerVelocity * Time.deltaTime);*/
    }
}
