using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        if (gameObject.CompareTag("Enemy"))
        {
            Debug.Log(rb.velocity.z);
        }
    }
}
