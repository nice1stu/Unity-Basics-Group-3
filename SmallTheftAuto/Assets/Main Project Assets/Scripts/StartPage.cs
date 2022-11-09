using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPage : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadGame()
    {
        Debug.Log("Load Game");
    }
    public void ExitGame()
    {
        Debug.Log("Quit Game... Thanks for playing");
        Application.Quit();
    }
}
