using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SCR_EnemyAttackManager : MonoBehaviour
{
    [SerializeField] private UnityEvent TurnEvent;
    [SerializeField] private UnityEvent DamageEvent;

    public void InvokeEvent()
    {
        TurnEvent.Invoke();
    }

    public void OnDamageEnemy()
    {
        DamageEvent.Invoke();
    }
       
}
