using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_CheckForAbilities : MonoBehaviour
{
    [SerializeField]
    private GameObject AbilityUnlocker;
    public int AbilityId;

  

    public bool unlocked;

    [SerializeField]
    private GameObject Blocker;

    void Start()
    {
        
        Debug.Log(AbilityId);

        if (AbilityUnlocker.GetComponent<SCROB_RootAbilityManager>().AbilitiesUnlocked[AbilityId] ==true)
        {
          
            Blocker.SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
  


}
