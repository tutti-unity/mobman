using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PacmanAnimation : MonoBehaviour
{
    private IMovement movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.Direction == Vector2.right) {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (movement.Direction == Vector2.left) {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        if (movement.Direction == Vector2.down) {
            transform.eulerAngles = new Vector3(0, 0, 270);
        }
        if (movement.Direction == Vector2.up) {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
    }
}
