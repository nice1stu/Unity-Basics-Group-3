using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject PauseMenuUI;
    public GameObject player;
    public NumericValue moneyCollected;
    public NumericValue hp;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void LoadGame()
    {
        //Debug.Log("Load Game...");
        float playerPositionX = PlayerPrefs.GetFloat("playerPositionX");
        float playerPositionY = PlayerPrefs.GetFloat("playerPositionY");
        float playerPositionZ = PlayerPrefs.GetFloat("playerPositionZ");
        Vector3 playerPosition = new Vector3(playerPositionX, playerPositionY, playerPositionZ);
        moneyCollected.value = PlayerPrefs.GetInt("moneyCollected");
        hp.value = PlayerPrefs.GetInt("playerHealth");
        Debug.Log("playerPosition" + playerPosition + "PlayerHealth" + hp.value + "moneyCollected" + moneyCollected.value);

        player.transform.position = playerPosition;
    }

    public void RestartGame()
    {
        Debug.Log("Restart Game");
        SceneManager.LoadScene("StartMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Exit Game ... Thanks for playing");
        Application.Quit();
    }
}
