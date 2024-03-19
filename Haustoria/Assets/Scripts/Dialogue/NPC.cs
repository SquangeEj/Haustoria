using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string npcName = "Enter Name IN INspector";
    public Dialogue dialogue;
    bool inConversation;
    bool playerInZone;

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && playerInZone )
        {
            Interact();
        }
    }

    void Interact()
    {
        if (inConversation)
        {
            DialogueManager.instance.SkipLine();
        }
        else
        {
            DialogueManager.instance.StartDialogue(dialogue, 0, npcName);
        }
    }

    void JoinConversation()
    {
        inConversation = true;
    }

    void LeaveConversation()
    {
        inConversation = false;
    }

    private void OnEnable()
    {
        DialogueManager.OnDialogueStarted += JoinConversation;
        DialogueManager.OnDialogueEnded += LeaveConversation;
    }

    private void OnDisable()
    {
        DialogueManager.OnDialogueStarted -= JoinConversation;
        DialogueManager.OnDialogueEnded -= LeaveConversation;
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
        }
    }
}
