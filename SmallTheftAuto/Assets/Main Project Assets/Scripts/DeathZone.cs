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
    public int playerHealth;


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(10000);
        }
    }
    public void death()
    {
        Wasted.SetActive(true);
    }
    

    public void respawn()
    {
        Time.timeScale = 1;
        Money.text = "Money: " + dosh.value;
        GreyDeathScreen.SetActive(false);
        Wasted.SetActive(false);
        Player.transform.position = destination.position;
        Debug.Log("Load Game...");
        float playerPositionX = PlayerPrefs.GetFloat("playerPositionX");
        float playerPositionY = PlayerPrefs.GetFloat("playerPositionY");
        float playerPositionZ = PlayerPrefs.GetFloat("playerPositionZ");
        Vector3 playerPosition = new Vector3(playerPositionX, playerPositionY, playerPositionZ);
        dosh.value = PlayerPrefs.GetInt("moneyCollected")/2;
        playerHealth = PlayerPrefs.GetInt("playerHealth");
        Debug.Log("playerPosition" + playerPosition + "PlayerHealth" + playerHealth + "moneyCollected" + dosh.value);

        Player.transform.position = playerPosition;
        
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
