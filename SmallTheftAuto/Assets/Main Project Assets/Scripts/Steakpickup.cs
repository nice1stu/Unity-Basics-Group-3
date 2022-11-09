using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Steakpickup : MonoBehaviour
{
    public NumericValue dosh;
    public GameObject Questcomplete;
    public GameObject Steak;
    public TextMeshProUGUI Money;

   
    private void OnTriggerEnter(Collider other)
    {
        dosh.value += 500;
        Money.text = "Money: "+ dosh.value;
        Questcomplete.SetActive(true);
        Invoke("deactivate", 2f);
        Steak.SetActive(false);
    }

    void deactivate()
    {
        Questcomplete.SetActive(false);
    }
}
