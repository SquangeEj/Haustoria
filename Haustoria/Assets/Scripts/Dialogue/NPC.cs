using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject dialogueCanvas;
    public Dialogue dialogue;
    public bool playerInZone;

    private bool inDialogue;
        
    private void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.E) && !inDialogue)
        {
            StartDialogue();
        }
    }

    private void StartDialogue()
    {
        inDialogue = true;
        dialogueCanvas.SetActive(true);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void EndDialogue()
    {
        inDialogue = false;
        dialogueCanvas.SetActive(false);
    }

    public void ContinueDialogue(int responseIndex)
    {
        // Get the DialogueManager instance
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();

        // Call the method to handle the response index
        dialogueManager.OnResponseButtonClicked(responseIndex);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
            EndDialogue();
        }
    }
}
