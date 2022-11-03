using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    private float verticalInput;
    private float horizontalInput;

    public bool driving;
    void drive()
    {
        if (horizontalInput > .1f)
        {
            transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
        }
        if (horizontalInput < -.1f)
        {
            transform.Rotate(0f, -rotateSpeed * Time.deltaTime, 0f);
        }
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(0, 0, verticalInput * moveSpeed * Time.deltaTime);

    }
    void Update()
    {
        if (driving)
        {
            drive();
        }
    }

}
