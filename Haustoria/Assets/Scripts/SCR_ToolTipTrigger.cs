using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SCR_ToolTipTrigger : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField] private string content, header;

    [SerializeField] private GameObject tooltip;

    public void OnPointerEnter(PointerEventData eventData)
    {
        SCR_ToolTipSystem.Show(content,header);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SCR_ToolTipSystem.Hide();
    }


}
