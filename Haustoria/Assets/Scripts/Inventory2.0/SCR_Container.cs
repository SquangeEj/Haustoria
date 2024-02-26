using System.Collections.Generic;
using UnityEngine;

public class SCR_Container : MonoBehaviour
{
    public List<SlotClass> items = new List<SlotClass>(); // List of items in the container
    public GameObject containerUIPrefab; // Reference to the UI prefab for displaying container items
    private GameObject containerUIInstance; // Instance of the UI prefab

    private bool playerInRange = false;

    private void Start()
    {
        // Instantiate the container UI prefab and deactivate it
        if (containerUIPrefab != null)
        {
            containerUIInstance = containerUIPrefab;
            containerUIInstance.SetActive(false);
        }
    }

    private void Update()
    {
        // Open the container UI when the player presses the key (E)
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (containerUIInstance != null)
            {
                containerUIInstance.SetActive(true);
                // Pass the container reference to the UI script
                SCR_ContainerUI containerUIScript = containerUIInstance.GetComponentInChildren<SCR_ContainerUI>();
                if (containerUIScript != null)
                {
                    containerUIScript.SetContainer(this);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            // Close the container UI if the player exits the collider area
            if (containerUIInstance != null)
            {
                containerUIInstance.SetActive(false);
            }
        }
    }
}