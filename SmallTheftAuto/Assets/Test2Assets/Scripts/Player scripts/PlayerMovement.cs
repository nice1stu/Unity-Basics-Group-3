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
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance;
        if(plane.Raycast(ray, out distance)) {
            Vector3 target=ray.GetPoint(distance);
            Vector3 direction=target-transform.position;
            float rotation=Mathf.Atan2(direction.x, direction.z)*Mathf.Rad2Deg;
            transform.rotation=Quaternion.Euler(0, rotation, 0);
        }
        // Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        // Quaternion target = Quaternion.LookRotation(new Vector3(mousePos.x, transform.position.y, mousePos.z) - transform.position, Vector3.up);
        // rb.rotation = Quaternion.Slerp(rb.rotation, target, rotationSmoothness);
    }
}
