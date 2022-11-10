using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPage : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }
    public void LoadGame()
    {
        Debug.Log("Load Game");
        SceneManager.LoadScene("MainGameScene");
        FindObjectOfType<PauseMenu>().LoadGame();
    }
    public void ExitGame()
    {
        Debug.Log("Quit Game... Thanks for playing");
        Application.Quit();
    }
}
