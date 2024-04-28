using System.Collections.Generic;
using UnityEngine;

public class SCR_Container : MonoBehaviour
{
    public List<SlotClass> items = new List<SlotClass>(); // List of items in the container
    public GameObject containerUIPrefab; 
    private GameObject containerUIInstance;

    private MeshRenderer meshRenderer;
    public Material openCrate;
    public Material closedCrate;

    private bool playerInRange = false;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = closedCrate;


        if (containerUIPrefab != null)
        {
            containerUIInstance = containerUIPrefab;
            containerUIInstance.SetActive(false);
        }
    }

    private void Update()
    {
        // Open the container UI when the player Right Clicks 
        if (playerInRange && Input.GetMouseButtonDown(0) && !containerUIInstance.activeSelf)
        {
            meshRenderer.material = openCrate;


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
            meshRenderer.material = closedCrate;

            // Close the container UI if the player exits the collider area
            if (containerUIInstance != null)
            {
                containerUIInstance.SetActive(false);
            }
        }
    }
}