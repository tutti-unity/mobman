using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inputs : MonoBehaviour
{

    private Movement movement;
    private Vector2 nextDirection = Vector2.right;
    [SerializeField]
    float distance = 0.5f;
    [SerializeField]
    float width = 0.5f;
    [SerializeField]
    LayerMask layerMask = 1;

    void Start()
    {
        movement = GetComponent<Movement>();
    }
    public void OnLeftInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed) {
            nextDirection = Vector2.left;
        }
    }

    public void OnRightInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed) {
            nextDirection = Vector2.right;
        }
    }

    public void OnUpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed) {
            nextDirection = Vector2.up;
        }
    }

    public void OnDownInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed) {
            nextDirection = Vector2.down;
        }
    }

    public void Update()
    {
        if (CanGo(nextDirection)) {
            movement.Direction = nextDirection;
        }
        // FIXME - PacMan si incastra...
        // if (!CanGo(movement.Direction)) {
        //     movement.Direction = Vector2.zero;
        // }
    }


    private bool CanGo(Vector3 direction)
    {
        return !Physics2D.Linecast(
            Vector3.Cross(direction * distance, Vector3.forward) * width + transform.position + direction * distance,
            Vector3.Cross(direction * distance, Vector3.back) * width + transform.position + direction * distance,
            layerMask);
    }

    void OnDrawGizmos() {
        Vector3 d = movement.Direction;
        Gizmos.color = CanGo(d) ? Color.green : Color.red;
        Gizmos.DrawLine(
            (Vector2)(Vector3.Cross(d * distance, Vector3.forward) * width + transform.position + d * distance),
            (Vector2)(Vector3.Cross(d * distance, Vector3.back) * width + transform.position + d * distance));
    }
}
