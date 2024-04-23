using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class SCR_SpeechCutscene : MonoBehaviour
{


    [SerializeField]
    private TMP_Text TextToAlter;

    private int currentVisibleCharacterIndex;
    private Coroutine _typerwriterCoroutine;
    private Coroutine _HideCouroutine;

    private WaitForSeconds _simpleDelay;
    private WaitForSeconds _IPDelay;

    [SerializeField]
    private string[] TextsToSay;
    int CurrentText;

    [Header("Typewriter Settings")]
    [SerializeField] private float charactersPerSecond = 20;
    [SerializeField] private float IPDelay = 0.5f;

    [SerializeField]
    private UnityEvent EventInvoker;

    // skipping dialogue



    [Header("Skip Options")]
    [SerializeField] private bool quickSkip = true;
    //[SerializeField] [Min(1)] private int skipSpeedup = 5;





    private void Awake()
    {
        TextToAlter = GetComponent<TMP_Text>();

        _simpleDelay = new WaitForSeconds(1 / charactersPerSecond);
        _IPDelay = new WaitForSeconds(IPDelay);

        CurrentText = 0;
        SetText();
        //_skipDelay = new WaitForSeconds(1 / (charactersPerSecond * skipSpeedup));
    }



    public void SetText()
    {

    
        if (_typerwriterCoroutine != null)
        {

            StopCoroutine(_typerwriterCoroutine);
        }



        TextToAlter.text = TextsToSay[CurrentText];
        TextToAlter.maxVisibleCharacters = 0;
        currentVisibleCharacterIndex = 0;

        _typerwriterCoroutine = StartCoroutine(TypeWriter());
    }


    private IEnumerator TypeWriter()
    {


        if (_HideCouroutine != null)
        {
            StopCoroutine(_HideCouroutine);
   
        }
        TMP_TextInfo textInfo = TextToAlter.textInfo;

        while (currentVisibleCharacterIndex < textInfo.characterCount + 1)
        {
          

            if (currentVisibleCharacterIndex < textInfo.characterInfo.Length)
            {

                char character = textInfo.characterInfo[currentVisibleCharacterIndex].character;

                TextToAlter.maxVisibleCharacters++;

                if (character == '?' || character == '.' || character == ',' || character == ':' ||
                    character == ';' || character == '!' || character == '-')
                {
                    yield return _IPDelay;
                }
                else
                {
                    yield return _simpleDelay;
                }

                currentVisibleCharacterIndex++;
            }
            else
            {
                break;
            }
        }

        yield return new WaitForSeconds(1f);
        CurrentText += 1;
        
        if(CurrentText < TextsToSay.Length)
        {
            SetText();
        }
        else
        {
            EventInvoker.Invoke();
        }

        yield return null;

    }






}
