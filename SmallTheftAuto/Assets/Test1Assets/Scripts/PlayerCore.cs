using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI dollars;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) //Save Game
        {
            Vector3 playerPosition = player.transform.position;
            PlayerPrefs.SetFloat("playerPositionX", playerPosition.x);
            PlayerPrefs.SetFloat("playerPositionY", playerPosition.y);
            PlayerPrefs.SetFloat("playerPositionZ", playerPosition.z);
            PlayerPrefs.SetString("dollars", dollars.text);
            PlayerPrefs.Save();
            Debug.Log("playerPosition" + playerPosition + dollars);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            float playerPositionX = PlayerPrefs.GetFloat("playerPositionX");
            float playerPositionY = PlayerPrefs.GetFloat("playerPositionY");
            float playerPositionZ = PlayerPrefs.GetFloat("playerPositionZ");
            Vector3 playerPosition = new Vector3(playerPositionX, playerPositionY, playerPositionZ);
            Debug.Log(playerPosition);

            player.transform.position = playerPosition;
        }
    }
}
