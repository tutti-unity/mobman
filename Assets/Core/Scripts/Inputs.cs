using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inputs : MonoBehaviour
{

    private Movement movement;

    void Start()
    {
        movement = GetComponent<Movement>();
    }
    public void OnLeftInput(InputAction.CallbackContext context)
    {
        movement.Direction = Vector2.left;
    }

    public void OnRightInput(InputAction.CallbackContext context)
    {
        movement.Direction = Vector2.right;
    }

    public void OnUpInput(InputAction.CallbackContext context)
    {
        movement.Direction = Vector2.up;
    }

    public void OnDownInput(InputAction.CallbackContext context)
    {
        movement.Direction = Vector2.down;
    }
}
