using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))] // Automatically adds the CharacterController component if not already present
public class SCR_Collisions : MonoBehaviour
{
    public Transform tpPoint;
    public CharacterController characterController;

    public UnityEvent onTeleport;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered!");

        if (tpPoint == null)
        {
            Debug.LogError("Teleport point not set!");
            return;
        }

        // Check if the collider belongs to the player.
        if (other.CompareTag("Player"))
        {
            // Add debug statements to check positions before and after teleport.
            Debug.Log("Player position before teleport: " + transform.position);

            characterController = other.GetComponent<CharacterController>();

            // Teleport the player to the destination.
            characterController.enabled = false; // Temporarily disable the CharacterController to set position.
            other.transform.position = tpPoint.position;
            characterController.enabled = true; // Re-enable the CharacterController.

            // Add a debug statement to confirm the player's new position.
            Debug.Log("Player position after teleport: " + transform.position);

            Debug.Log("Player teleported.");

            // Ensure that the CharacterController is properly positioned by updating its internal state.
            characterController.Move(Vector3.zero);

            onTeleport.Invoke();
        }
    }
}
