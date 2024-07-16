using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TeleportDoor : MonoBehaviour
{
    BoxCollider2D boxCollider;

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform exitCollider;
    [SerializeField] private Vector3 offset;

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (layerMask.Contains(collider.gameObject.layer))
        {
            collider.gameObject.transform.position = exitCollider.position + offset;
        }
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
