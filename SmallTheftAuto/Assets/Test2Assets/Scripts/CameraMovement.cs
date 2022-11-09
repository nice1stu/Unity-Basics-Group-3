using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float smoothness;
    private Vector3 velocity = Vector3.zero;
    private float cameraAngle = 0;
    public float targetAngle = 0;
    private float angularVelocity;

    public bool isDriving;
    private void Update()
    {
        CamFollow();
        cameraAngle = Mathf.SmoothDampAngle(cameraAngle, targetAngle, ref angularVelocity, 0.2f);
        transform.localEulerAngles = new Vector3(cameraAngle,0, 0);
        if (isDriving)
        {
            transform.LookAt(player.position);
        }
    }

    void CamFollow()
    {
        Vector3 targetPosition = player.position + player.transform.localToWorldMatrix.MultiplyVector(offset);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothness);
    }
}
