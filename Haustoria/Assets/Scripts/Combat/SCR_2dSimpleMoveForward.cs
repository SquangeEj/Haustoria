using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_2dSimpleMoveForward : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (transform.right * 2) * Time.deltaTime;   
    }
}
