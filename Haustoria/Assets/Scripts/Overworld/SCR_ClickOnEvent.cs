using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SCR_ClickOnEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent onClickEvent;

 
    private void OnMouseDown()
    {
       
        onClickEvent.Invoke();
    }
}
