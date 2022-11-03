using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    public float enterCarRange = 2;
    private Vehicle vehicle;


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
    }
}
