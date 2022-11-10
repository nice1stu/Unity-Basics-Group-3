using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public GameObject player;
    public NumericValue moneyCollected;
    public NumericValue hp;
    // Update is called once per frame
    
        void OnTriggerEnter(Collider other)
        {
            Save();
        }

        void Save()
        {
            hp = FindObjectOfType<PlayerStatus>().hp;
            Vector3 playerPosition = player.transform.position;
            PlayerPrefs.SetFloat("playerPositionX", playerPosition.x);
            PlayerPrefs.SetFloat("playerPositionY", playerPosition.y);
            PlayerPrefs.SetFloat("playerPositionZ", playerPosition.z);
            PlayerPrefs.SetInt("moneyCollected", moneyCollected.value);
            PlayerPrefs.SetInt("playerHealth", hp.value);
            PlayerPrefs.Save();
            Debug.Log("playerPosition " + playerPosition + ", PlayerHealth " + hp.value + ", moneyCollected " + moneyCollected.value); 
        }
}
