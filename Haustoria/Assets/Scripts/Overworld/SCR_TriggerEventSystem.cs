using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SCR_TriggerEventSystem : MonoBehaviour
{
    [SerializeField] private UnityEvent OnTriggerEvent;

    [SerializeField] private UnityEvent OnTriggerLeave;

    [SerializeField] private bool DeleteAfter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
          
            OnTriggerEvent.Invoke();
            if (DeleteAfter == true)
            {
                Destroy(this);
            }
        }
    }


    private void OnTriggerExit(Collider other)
     {
         
         if (other.gameObject.CompareTag("Player"))
         {
           
            OnTriggerLeave.Invoke();
             if (DeleteAfter == true)
             {
                 Destroy(this);
             }
         }
     }

    
  

}
