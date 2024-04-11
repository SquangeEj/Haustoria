using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] GameObject answerBox;
    [SerializeField] Button[] answerObjects;

    public static event Action OnDialogueStarted;
    public static event Action OnDialogueEnded;

    bool skipLineTriggered;
    bool answerTriggered;
    int answerIndex;

    GameObject briar;
    SCR_BRIAR_MOVEMENT moveScript;

    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        briar = GameObject.FindGameObjectWithTag("Player");
        moveScript = briar.GetComponent<SCR_BRIAR_MOVEMENT>();
    }

    public void StartDialogue(Dialogue dialogueData, int startSection, string name)
    {
        ResetBox();
        nameText.text = name;
        dialogueBox.SetActive(true);
        OnDialogueStarted?.Invoke();
        //Pause Player or Time 
        Time.timeScale = 0f;
        if (moveScript != null)
        {
            moveScript.enabled = false;
        }

        StartCoroutine(RunDialogue(dialogueData, startSection));
    }

    IEnumerator RunDialogue(Dialogue dialogueData, int section)
    {
        for (int i = 0; i < dialogueData.sections[section].dialogue.Length; i++)
        {
            dialogueText.text = dialogueData.sections[section].dialogue[i];
            while (skipLineTriggered == false)
            {
                yield return null;
            }
            skipLineTriggered = false;
        }

        if (dialogueData.sections[section].endAfterDialogue)
        {
            OnDialogueEnded?.Invoke();
            dialogueBox.SetActive(false);
            //Im using 2 ways to freeze time during Dialogues
            moveScript.enabled = true;
            Time.timeScale = 1f;

            yield break;
        }

        dialogueText.text = dialogueData.sections[section].branchPoint.question;
        ShowAnswers(dialogueData.sections[section].branchPoint);

        while (answerTriggered == false)
        {
            yield return null;
        }
        answerBox.SetActive(false);
        answerTriggered = false;

        StartCoroutine(RunDialogue(dialogueData, dialogueData.sections[section].branchPoint.answers[answerIndex].nextElement));
    }

    public void ResetBox()
    {
        StopAllCoroutines();
        dialogueBox.SetActive(false);
        answerBox.SetActive(false);
        skipLineTriggered = false;
        answerTriggered = false;
    }

    void ShowAnswers(BranchPoint branchPoint)
    {
        // Reveals the aselectable answers and sets their text values
        answerBox.SetActive(true);
        for (int i = 0; i < branchPoint.answers.Length; i++)
        {
            if (i < branchPoint.answers.Length)
            {
                answerObjects[i].GetComponentInChildren<TextMeshProUGUI>().text = branchPoint.answers[i].answerLabel;
                answerObjects[i].gameObject.SetActive(true);
            }
            else
            {
                answerObjects[i].gameObject.SetActive(false);
            }
        }
    }

    public void SkipLine()
    {
        skipLineTriggered = true;
    }

    public void AnswerQuestion(int answer)
    {
        answerIndex = answer;
        answerTriggered = true;
    }
}
