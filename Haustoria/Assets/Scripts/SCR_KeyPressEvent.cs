using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SCR_KeyPressEvent : MonoBehaviour
{
    public UnityEvent onIKeyPress;
    private bool isPaused = false;

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.I)) // 'I' key to Open Inventory
        {
            // Trigger the Unity event
            onIKeyPress.Invoke();

        }

        if (Input.GetKeyDown(KeyCode.P)) //P to Pause Game
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            // Pause the game
            Time.timeScale = 0f;
            Debug.Log("Game paused.");
        }
        else
        {
            // Resume the game
            Time.timeScale = 1f;
            Debug.Log("Game resumed.");
        }
    }
}