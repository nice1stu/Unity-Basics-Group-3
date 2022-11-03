using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Driver : MonoBehaviour
{
    public float enterCarRange = 2;
    public CameraMovement cam;

    private Vehicle vehicle;

    public bool inCar;
    private void Update()
    {
        EnterExitCar();
    }

    void EnterExitCar()
    {
        if (EnterCarInput)
        {
            if (IsWithinCarDistance)
            {
                EnterCar();
            }
        }
    }



    private bool EnterCarInput => Input.GetButtonDown("InteractInput");

    Transform GetClosestCar()
    {
        Transform closestCar = null;
        Vehicle[] vehicles = FindObjectsOfType<Vehicle>();
        float minDist = Mathf.Infinity;
        foreach (Vehicle vehicle in vehicles)
        {
            Transform t = vehicle.transform;
            float dist = Vector3.Distance(t.position, transform.position);
            if (dist < minDist)
            {
                closestCar = t;
                minDist = dist;
            }
        }

        if (closestCar == null)
            return null;

        vehicle = closestCar.GetComponent<Vehicle>();
        return closestCar;

    }

    private bool IsWithinCarDistance => Vector3.Distance(transform.position, GetClosestCar().position) <= enterCarRange;

    void EnterCar()
    {
        transform.position = GetClosestCar().transform.position;
        transform.SetParent(GetClosestCar());
        gameObject.SetActive(false);
        vehicle.driving = true;
        inCar = true;
        vehicle.driver = gameObject;
        vehicle.cam = cam; 
        cam.offset = new Vector3(cam.offset.x, Mathf.Lerp(13, 18, 20),cam.offset.z);
        //cam.offset = new Vector3(cam.offset.x, Mathf.Lerp(10, 18, 20), Mathf.Lerp(0, -14, 20));
        //cam.transform.eulerAngles = new Vector3(Mathf.Lerp(90, 45, 20), cam.transform.rotation.y, cam.transform.rotation.z);
    }
}
