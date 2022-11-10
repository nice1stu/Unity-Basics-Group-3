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
    public NumericValue hp;


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
        hp = FindObjectOfType<PlayerStatus>().hp;
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
        hp.value = PlayerPrefs.GetInt("playerHealth");
        Debug.Log("playerPosition" + playerPosition + "PlayerHealth" + hp.value + "moneyCollected" + dosh.value);

        Player.transform.position = playerPosition;
        
    }
}
