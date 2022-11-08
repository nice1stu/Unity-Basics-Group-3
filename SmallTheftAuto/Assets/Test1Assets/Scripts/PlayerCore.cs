using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    public GameObject player;

    public int moneyCollected;

    public int playerHealth;

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Q)) //Save Game
        {
            Vector3 playerPosition = player.transform.position;
            PlayerPrefs.SetFloat("playerPositionX", playerPosition.x);
            PlayerPrefs.SetFloat("playerPositionY", playerPosition.y);
            PlayerPrefs.SetFloat("playerPositionZ", playerPosition.z);
            PlayerPrefs.SetInt("moneyCollected", moneyCollected);
            PlayerPrefs.SetInt("playerHealth", playerHealth);
            //PlayerPrefs.SetString("dollars", dollars.text);
            PlayerPrefs.Save();
            Debug.Log("playerPosition" + playerPosition + "PlayerHealth" + playerHealth + "moneyCollected" + moneyCollected);
        }*/

        if (Input.GetKeyDown(KeyCode.E)) //Load Game
        {
            float playerPositionX = PlayerPrefs.GetFloat("playerPositionX");
            float playerPositionY = PlayerPrefs.GetFloat("playerPositionY");
            float playerPositionZ = PlayerPrefs.GetFloat("playerPositionZ");
            Vector3 playerPosition = new Vector3(playerPositionX, playerPositionY, playerPositionZ);
            moneyCollected = PlayerPrefs.GetInt("moneyCollected");
            playerHealth = PlayerPrefs.GetInt("playerHealth");
            Debug.Log("playerPosition" + playerPosition + "PlayerHealth" + playerHealth + "moneyCollected" + moneyCollected);

            player.transform.position = playerPosition;
        }
    }
}
