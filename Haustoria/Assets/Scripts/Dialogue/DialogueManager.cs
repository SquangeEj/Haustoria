using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Button[] responseButtons;

    private Dialogue currentDialogue;
    private int currentSentenceIndex;
    private bool dialogueInProgress;

    public void StartDialogue(Dialogue dialogue)
    {
        currentDialogue = dialogue;
        currentSentenceIndex = 0;
        nameText.text = dialogue.name;
        dialogueInProgress = true;
        DisplayCurrentSentence();
        UpdateResponseOptions(false); // Initially disable response buttons
    }

    private void DisplayCurrentSentence()
    {
        // Check if there are sentences left to display
        if (currentSentenceIndex < currentDialogue.sentences.Length)
        {
            dialogueText.text = currentDialogue.sentences[currentSentenceIndex];
            currentSentenceIndex++;
        }
        else if (currentDialogue.responseOptions != null && currentDialogue.responseOptions.Length > 0)
        {
            // Check if there are response options available
            UpdateResponseOptions(true); // Enable response buttons
            SetResponseButtonsText();
        }
        else
        {
            // No more sentences or response options, end dialogue
            EndDialogue();
            return; // Exit the method early
        }
    }


    private void SetResponseButtonsText()
    {
        for (int i = 0; i < responseButtons.Length; i++)
        {
            if (i < currentDialogue.responseOptions.Length)
            {
                responseButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentDialogue.responseOptions[i].optionText;
                responseButtons[i].gameObject.SetActive(true); // Make sure the button is active
            }
            else
            {
                responseButtons[i].gameObject.SetActive(false); // Hide extra buttons
            }
        }
    }

    public void OnResponseButtonClicked(int responseIndex)
    {
        if (responseIndex >= 0 && responseIndex < currentDialogue.responseOptions.Length)
        {
            currentDialogue = currentDialogue.responseOptions[responseIndex].nextDialogue;
            currentSentenceIndex = 0;
            DisplayCurrentSentence();
            UpdateResponseOptions(false);
        }
        else
        {
            Debug.LogWarning("Invalid response index: " + responseIndex);
        }
    }

    private void UpdateResponseOptions(bool active)
    {
        foreach (Button button in responseButtons)
        {
            button.gameObject.SetActive(active);
        }
    }

    private void EndDialogue()
    {
        dialogueInProgress = false;
    }

    private void Update()
    {
        // Example: Continue dialogue with left mouse button click
        if (dialogueInProgress && Input.GetMouseButtonDown(0))
        {
            DisplayCurrentSentence();
        }
    }
}
