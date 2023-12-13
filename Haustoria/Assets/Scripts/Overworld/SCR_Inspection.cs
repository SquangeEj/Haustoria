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

    private WaitForSeconds _simpleDelay;
    private WaitForSeconds _IPDelay;


    [Header("Typewriter Settings")]
    [SerializeField] private float charactersPerSecond = 20;
    [SerializeField] private float IPDelay = 0.5f;
    


    private void Awake()
    {
        TextToAlter = GetComponent<TMP_Text>();

        _simpleDelay = new WaitForSeconds(1 / charactersPerSecond);
        _IPDelay = new WaitForSeconds(IPDelay);
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
            StopCoroutine(_typerwriterCoroutine);

        

        TextToAlter.text = text;
        TextToAlter.maxVisibleCharacters = 0;
        currentVisibleCharacterIndex = 0;

        _typerwriterCoroutine = StartCoroutine(TypeWriter());
    }


    private IEnumerator TypeWriter()
    {
        TMP_TextInfo textInfo = TextToAlter.textInfo;

        while(currentVisibleCharacterIndex < textInfo.characterCount +1)
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

       yield return new WaitForSeconds(TimeOnScreen);

        TextToAlter.text = null;
        TextBox.SetActive(false);
        TalkSprite.sprite = null;
        CharPortrait.SetActive(false);
        
        yield return null;

    }





}
