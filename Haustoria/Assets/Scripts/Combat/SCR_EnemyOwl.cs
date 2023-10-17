using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_EnemyOwl : MonoBehaviour
{

    [SerializeField] private GameObject CombatManager;
    public void EnemyAttack() 
    {
        StartCoroutine(Owlattack());
    }


    public IEnumerator Owlattack()
    {


        Debug.Log("I am attacking");

        yield return new WaitForSeconds(10f);

        CombatManager.GetComponent<SCR_EnemySelect>().BriarTurn();

        yield return null;
    }
}
