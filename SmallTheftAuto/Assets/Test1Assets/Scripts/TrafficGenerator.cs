using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficGenerator : MonoBehaviour
{
    //[SerializeField] GameObject[] waypoints;
    public GameObject movingObject; //car or pedestrian
    //public int speed;
    //private int currentWaypoint = 0;
    //private float waypointRadius = 2;

    void Start()
    {
        Instantiate(movingObject, transform.position, Quaternion.identity);
        Debug.Log("spawn car");
    }

    /*void Update()
    {

    if (Vector3.Distance(transform.position, waypoints[currentWaypoint].transform.position) < waypointRadius)
    {
        currentWaypoint++;
        if (currentWaypoint >= waypoints.Length)
        {
            currentWaypoint = 0;
        }

    }

    transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, speed * Time.deltaTime);
    }*/
}


