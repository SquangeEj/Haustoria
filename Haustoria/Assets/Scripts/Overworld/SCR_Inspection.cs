using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SCR_Inspection : MonoBehaviour
{
    public string InspectText;

    public int TimeOnScreen;

    [SerializeField] private GameObject TextBox;
    [SerializeField] private Image TalkSprite;
    [SerializeField] private GameObject CharPortrait;

    [SerializeField]
    private TMP_Text TextToAlter;

    private int currentVisibleCharacterIndex;
    private Coroutine _typerwriterCoroutine;
    private Coroutine _HideCouroutine;

    private WaitForSeconds _simpleDelay;
    private WaitForSeconds _IPDelay;


    [Header("Typewriter Settings")]
    [SerializeField] private float charactersPerSecond = 20;
    [SerializeField] private float IPDelay = 0.5f;
    

    // skipping dialogue

    public bool CurrentlySkipping { get; private set; }
    private WaitForSeconds _skipDelay;
  

    [Header("Skip Options")]
    [SerializeField] private bool quickSkip = true;
    //[SerializeField] [Min(1)] private int skipSpeedup = 5;





    private void Awake()
    {
        TextToAlter = GetComponent<TMP_Text>();

        _simpleDelay = new WaitForSeconds(1 / charactersPerSecond);
        _IPDelay = new WaitForSeconds(IPDelay);

        //_skipDelay = new WaitForSeconds(1 / (charactersPerSecond * skipSpeedup));
    }

    private void Update()
    {
       

        if (Input.GetButton("Fire2") || Input.GetButton("Jump"))
        {
            if (TextToAlter.maxVisibleCharacters != TextToAlter.textInfo.characterCount - 1)
            {

                StartCoroutine(Skip());
                
            }
        }
    }

    private IEnumerator Skip()
    {
        CurrentlySkipping = true;
        StopCoroutine(_typerwriterCoroutine);
        TextToAlter.maxVisibleCharacters = TextToAlter.textInfo.characterCount;
        yield return new WaitForSeconds(TimeOnScreen);
        hidetext(); 
    }



    public void SetTime(int time)
    {
        TimeOnScreen = time;
    }


    public void HasSprite(bool hassprite)
    {
        if (hassprite == false)
        {
            TalkSprite.sprite = null;
            CharPortrait.SetActive(false);
        }
        else
        {
            CharPortrait.SetActive(true);
        }
    }

    public void SetSprite(Sprite image)
    {
      
      
            TalkSprite.sprite = image;
       
      
    }

    public void SetText(string text)
    {
       
        if (TalkSprite.sprite != null)
        {
            CharPortrait.SetActive(true);
        }
      

        TextBox.SetActive(true);
        if (_typerwriterCoroutine != null)
        {
           
            StopCoroutine(_typerwriterCoroutine);
        }

        

        TextToAlter.text = text;
        TextToAlter.maxVisibleCharacters = 0;
        currentVisibleCharacterIndex = 0;

        _typerwriterCoroutine = StartCoroutine(TypeWriter());
    }


    private IEnumerator TypeWriter()
    {

        if (_HideCouroutine != null)
        {
            StopCoroutine(_HideCouroutine);
            CurrentlySkipping = false;
        }
        TMP_TextInfo textInfo = TextToAlter.textInfo;

        while(currentVisibleCharacterIndex < textInfo.characterCount +1)
        {
            CurrentlySkipping = false;

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

   
            CurrentlySkipping = true;
            hidetext();

      
        yield return null;

    }


    private void hidetext()
    {


        if (CurrentlySkipping == true)
        {

      

            TextToAlter.text = null;
            TextBox.SetActive(false);
            TalkSprite.sprite = null;
            CharPortrait.SetActive(false);

            StopCoroutine(_typerwriterCoroutine);
        }
  
       
        
   
       

    }
   




}
