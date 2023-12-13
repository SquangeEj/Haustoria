using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_CameraRoom : MonoBehaviour
{
    private Camera mainCamera;
    public Transform Target;
    private Transform lastObstruction;

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        ViewObstructed();
    }

    private void Update()
    {
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
            }
            else
            {
                // Reset the last obstruction's shadowCastingMode to On
                ResetObstruction();
            }
        }
        else
        {
            // Reset the last obstruction's shadowCastingMode to On if no obstruction is found
            ResetObstruction();
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
