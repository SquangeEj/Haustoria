using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_Manager_Combat : MonoBehaviour
{
    

   /* void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        
    }
*/
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            LeaveCombat();
            
        }
    }

    public void GoCombat()
    {

        SceneManager.LoadScene(1);
        
    }


    public void LeaveCombat()
    {

        SceneManager.LoadScene(0);

    }
}
