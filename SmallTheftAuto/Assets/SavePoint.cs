using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public GameObject player;
    public int moneyCollected;
    public int playerHealth;
    // Update is called once per frame
    
        void OnTriggerEnter(Collider other)
        {
            Vector3 playerPosition = player.transform.position;
            PlayerPrefs.SetFloat("playerPositionX", playerPosition.x);
            PlayerPrefs.SetFloat("playerPositionY", playerPosition.y);
            PlayerPrefs.SetFloat("playerPositionZ", playerPosition.z);
            PlayerPrefs.SetInt("moneyCollected", moneyCollected);
            PlayerPrefs.SetInt("playerHealth", playerHealth);
            PlayerPrefs.Save();
            Debug.Log("playerPosition " + playerPosition + ", PlayerHealth " + playerHealth + ", moneyCollected " +
                      moneyCollected);
        }
}
