using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_CameraRoom : MonoBehaviour
{
    private Camera mainCamera;
    public Transform Target;
    private Transform lastObstruction;
    public GameObject quadObject; // Reference to the quad GameObject

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        ViewObstructed();
        Debug.DrawLine(mainCamera.transform.position, Target.position, Color.blue);
    }

    void ViewObstructed()
    {
        RaycastHit hit;

        // Cast a ray from the target to the camera
        if (Physics.Raycast(Target.position, mainCamera.transform.position - Target.position, out hit))
        {
            if (!hit.collider.CompareTag("Player"))
            {
                Debug.Log("HIT SOMETHING");
                // Check if the last obstruction is different from the current one
                if (lastObstruction != hit.transform)
                {
                    // Reset the last obstruction's shadowCastingMode to On
                    ResetObstruction();
                }

                // Set the current obstruction and change its shadowCastingMode
                lastObstruction = hit.transform;
                MeshRenderer obstructionRenderer = lastObstruction.gameObject.GetComponent<MeshRenderer>();

                // Check if the MeshRenderer component is attached before accessing it
                if (obstructionRenderer != null)
                {
                    obstructionRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
                }

                // Deactivate the quad object
                quadObject.SetActive(false);
            }
            else
            {
                // Reset the last obstruction's shadowCastingMode to On
                ResetObstruction();

                // Activate the quad object
                quadObject.SetActive(true);
            }
        }
        else
        {
            // Reset the last obstruction's shadowCastingMode to On if no obstruction is found
            ResetObstruction();

            // Activate the quad object
            quadObject.SetActive(true);
        }
    }

    void ResetObstruction()
    {
        if (lastObstruction != null && lastObstruction.gameObject != null)
        {
            MeshRenderer obstructionRenderer = lastObstruction.gameObject.GetComponent<MeshRenderer>();

            // Check if the MeshRenderer component is attached before accessing it
            if (obstructionRenderer != null)
            {
                obstructionRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            }

            lastObstruction = null;
        }
    }
}
