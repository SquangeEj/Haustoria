using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_BRIAR_MOVEMENT : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip[] walkPathSoundClips;
    [SerializeField] private AudioClip[] walkGrassSoundClips;

    private CharacterController controller;

    private Animator animator;

    private AudioSource audioSource;

    private Vector3 playerVelocity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * moveSpeed);

        animator.SetFloat("Xmove", Input.GetAxis("Horizontal"));
        animator.SetFloat("Ymove", Input.GetAxis("Vertical"));



        // Footsteps Codez (need to add in a ray cast to check ground layer type for grass, road etc)
        
        if (controller.velocity.magnitude> 2f && audioSource.isPlaying == false) 
        {
            SCR_SoundFXManager.instance.PlayRandomFootstep(walkPathSoundClips, audioSource);
        }


        /* if (move != Vector3.zero)
         {
             gameObject.transform.forward = move;
         }

         controller.SimpleMove(playerVelocity * Time.deltaTime);*/
    }
}
