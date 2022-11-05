using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject Wasted;
    public GameObject Player;
    public Transform destination;

    private void OnTriggerEnter()
    {
        Wasted.SetActive(true);
        Time.timeScale = 0.3f;
        Invoke("respawn", 1f);
        
    }

    public void respawn()
    {
        Time.timeScale = 1;
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
