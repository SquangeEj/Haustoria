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
    public GameObject gameUI;
    [SerializeField]
    private LayerMask layerMask;

    private void Start()
    {
        gameUI = GameObject.FindGameObjectWithTag("GameUI");
        gameUI.SetActive(false);
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        briarStats = GetComponent<SCR_BriarStats>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleUI();
        }
      

        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleUI();
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
            // im so fucking sick of briar getting stuck on something and floating upwards, im putting a raycast that stops the little shithead from flying, he's never learned about gravity, stupid fucking farmer boy

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 2, layerMask))
            {
                return;
            }
            else
            {
                transform.position = transform.position + new Vector3(0, -0.1f, 0);
            }
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

    private void ToggleUI()
    {
        
        if (gameUI != null)
        {
            gameUI.SetActive(!gameUI.activeSelf);
        }
    } 

    public void playStepSound()
    {
       
      SCR_SoundFXManager.instance.PlayRandomFootstep(walkPathSoundClips, audioSource);
        
    }
}
