using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DeathZone : MonoBehaviour
{
    public NumericValue dosh;
    
    public GameObject GreyDeathScreen;
    public GameObject Wasted;
    public GameObject Player;
    public Transform destination;
    public TextMeshProUGUI Money;
    public int dollars;

   
    private void OnTriggerEnter(Collider other)
    {
        GreyDeathScreen.SetActive(true);
        Invoke("death", 0.5f);
        Time.timeScale = 0.3f;
        Invoke("respawn", 1f);
        
    }
    public void death()
    {
        dosh.value /= 2;
        Wasted.SetActive(true);
    }
    

    public void respawn()
    {
        Time.timeScale = 1;
        Money.text = "Money: " + dosh.value;
        GreyDeathScreen.SetActive(false);
        Wasted.SetActive(false);
        Player.transform.position = destination.position;
        
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
