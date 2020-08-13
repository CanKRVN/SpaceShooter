using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("boundry"))
        {
            Destroy(gameObject);
        }
    }

}
