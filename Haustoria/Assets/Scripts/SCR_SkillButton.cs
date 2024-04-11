using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SCR_SkillButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject toolTip;

    private void Start()
    {
        toolTip = transform.Find("Panel").gameObject;
        toolTip.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        toolTip.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        toolTip.SetActive(false);
    }
}
