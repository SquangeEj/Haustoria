using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SCR_ColliisionOnEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent onTriggervent;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onTriggervent.Invoke();
        }
    }
}
