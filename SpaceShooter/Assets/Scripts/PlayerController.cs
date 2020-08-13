using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float tilt;
    public Boundry boundry;
    public GameObject bolt;
    public Transform shotSpawn;
    public float firerate;
    float nextFire;
    private AudioSource ShotSound;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ShotSound = GetComponent<AudioSource>();

    }

    private void Update()
    {
        
        if (Input.GetButton("Jump") && Time.time > nextFire)
        {
            nextFire = Time.time + firerate;
            Instantiate(bolt, shotSpawn.position, shotSpawn.rotation);
            ShotSound.Play();


        }


        


    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);

        rb.velocity = movement * speed;
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, boundry.minX, boundry.maxX), rb.position.y, Mathf.Clamp(rb.position.z, boundry.minZ, boundry.maxZ));
        rb.rotation = Quaternion.Euler(0, 0, rb.velocity.x * -tilt);
    }




}

[System.Serializable]
public class Boundry
{
    public float minX, maxX, minZ, maxZ;
}
