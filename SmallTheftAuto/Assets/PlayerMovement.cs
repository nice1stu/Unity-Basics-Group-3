using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
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
        Vector3 movementVector = new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime); 
        rb.velocity = movementVector.normalized * speed;
    }

    void Look()
    {
        // Vector3 mousePos = cam.ScreenToWorldPoint (new Vector3(Input.mousePosition.x,Input.mousePosition.y, cam.transform.position.z-transform.position.z));
        //
        // transform.LookAt (mousePos);
        
        Vector3 mousePos = cam.ScreenToWorldPoint (Input.mousePosition);
        transform.LookAt (new Vector3 (mousePos.x, transform.position.y, mousePos.z));
    }
}
