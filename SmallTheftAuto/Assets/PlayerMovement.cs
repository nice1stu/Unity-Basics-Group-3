using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSmoothness = 0.1f;
    public Camera cam;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Movement();
        Look();
    }

    void Movement()
    {
        Vector3 movementVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")); 
        rb.velocity = movementVector.normalized * speed;
    }

    void Look()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint (Input.mousePosition);
        Quaternion target =
            Quaternion.LookRotation(new Vector3(mousePos.x, transform.position.y, mousePos.z) - transform.position, Vector3.up);
        
        rb.rotation = Quaternion.Slerp(rb.rotation, target, rotationSmoothness);
    }
}
