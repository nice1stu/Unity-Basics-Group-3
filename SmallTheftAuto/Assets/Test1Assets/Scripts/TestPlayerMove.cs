using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMove : MonoBehaviour
{
    public float speed = 10f;
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * (Time.deltaTime * speed * z));
        transform.Translate(Vector3.right * (Time.deltaTime * speed * x));
    }
}
