using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_BRIAR_MOVEMENT : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;

    [Header("Stamina")]

    [Header("Sound Effects")]
    [SerializeField] private AudioClip[] walkPathSoundClips;
    [SerializeField] private AudioClip[] walkGrassSoundClips;

    private CharacterController controller;
    private Animator animator;
    private AudioSource audioSource;
    private SCR_BriarStats briarStats; // Reference to SCR_BriarStats script
    private bool isPaused = false;
    public GameObject inventoryUI;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        briarStats = GetComponent<SCR_BriarStats>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }

        if (Input.GetKey(KeyCode.LeftShift) && IsMoving())
        {
            MovePlayer(moveSpeed + 5);
        }
        else
        {
            MovePlayer(moveSpeed);
        }


        MovePlayer(moveSpeed);
    }

    private bool IsMoving()
    {
        return Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
    }

    
    private void MovePlayer(float speed)
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontalInput, 0, verticalInput);
        controller.Move(move * Time.deltaTime * speed);

        
        if (move != Vector3.zero)
        {
            animator.Play("Blend Tree Running");
            animator.SetFloat("Xmove", horizontalInput);
            animator.SetFloat("Ymove", verticalInput);
        }
        else
        {
            animator.Play("Blend Tree Idle");
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
    }

    private void ToggleInventory()
    {
        
        if (inventoryUI != null)
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
        TogglePause();
    } 

    public void playStepSound()
    {
       
      SCR_SoundFXManager.instance.PlayRandomFootstep(walkPathSoundClips, audioSource);
        
    }
}
