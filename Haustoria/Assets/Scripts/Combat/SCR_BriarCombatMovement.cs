using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_BriarCombatMovement : MonoBehaviour
{
    public float MoveSpeed;
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0);

        transform.position += (move * MoveSpeed) * Time.deltaTime;
    }
}
