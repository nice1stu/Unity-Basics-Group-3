using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 20f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // void Update()
    // {
    //     rb.velocity = Vector3.forward * (bulletSpeed * Time.deltaTime);
    // }
}