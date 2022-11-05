using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steakpickup : MonoBehaviour
{
    public GameObject Steak;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(Steak);
    }
}
