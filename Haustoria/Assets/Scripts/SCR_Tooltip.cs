using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class SCR_Tooltip : MonoBehaviour
{
    [SerializeField] private RectTransform canvasRect;
    private RectTransform backgroundRect;
    private TextMeshProUGUI textmeshPro;
    private RectTransform rectTransform;
    [SerializeField] private EventSystem eventsy;

  
  
    private void Awake()
    {
        backgroundRect = transform.Find("Background").GetComponent<RectTransform>();
        textmeshPro = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        rectTransform = transform.GetComponent<RectTransform>();

        HideTooltip();
    }

    private void SetText(string tooltipText)
    {
        textmeshPro.SetText(tooltipText);
        textmeshPro.ForceMeshUpdate();

        Vector2 textSize = textmeshPro.GetRenderedValues(false);
        Vector2 paddingSize = new Vector2(50,25);


        backgroundRect.sizeDelta = textSize + paddingSize;
    }

    private void Update()
    {
        if (eventsy.currentSelectedGameObject != null)
        {
            Vector2 anchoredPosition = eventsy.currentSelectedGameObject.GetComponent<RectTransform>().position / canvasRect.localScale.x;


            if (anchoredPosition.x + backgroundRect.rect.width > canvasRect.rect.width)
            {
                anchoredPosition.x = canvasRect.rect.width - backgroundRect.rect.width;
            }

            if (anchoredPosition.y + backgroundRect.rect.height +75 > canvasRect.rect.height)
            {
                anchoredPosition.y = (canvasRect.rect.height - backgroundRect.rect.height) - 75;
            }


            rectTransform.anchoredPosition = anchoredPosition + new Vector2(0, 75);

            if (eventsy.currentSelectedGameObject.GetComponent<SCR_ToolTipTextHolder>())
            {
                ShowTooltip(eventsy.currentSelectedGameObject.GetComponent<SCR_ToolTipTextHolder>().ToolTipText);
            }
            else if (!eventsy.currentSelectedGameObject.GetComponent<SCR_ToolTipTextHolder>())
            {
                HideTooltip();
            }
        }
        else {
                HideTooltip();
            
        }
        
        
      
    }

    public void ShowTooltip(string tooltiptext)
    {
        backgroundRect.transform.gameObject.SetActive(true);
        textmeshPro.transform.gameObject.SetActive(true);
        SetText(tooltiptext);
    }

    public void HideTooltip()
    {
        backgroundRect.transform.gameObject.SetActive(false);
        textmeshPro.transform.gameObject.SetActive(false);
        
    }


}
