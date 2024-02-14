using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SCR_KeyPressEvent : MonoBehaviour
{
    public GameObject inventoryUI;
    private bool isInventoryVisible = false;

    private bool isPaused = false;

    void Start()
    {
        inventoryUI.SetActive(false);
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.I)) // 'I' key to Open Inventory
        {
            ToggleInventoryUI(); 

        }

        if (Input.GetKeyDown(KeyCode.P)) //P to Pause Game
        {
            TogglePause();
        }
    }

    public void ToggleInventoryUI()
    {
        isInventoryVisible = !isInventoryVisible;

        if (isInventoryVisible)
        {
            TogglePause();
            // Show the inventory UI
            inventoryUI.SetActive(true);
            Debug.Log("Inventory UI shown.");
        }
        else
        {
            TogglePause();
            // Hide the inventory UI
            inventoryUI.SetActive(false);
            Debug.Log("Inventory UI hidden.");
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