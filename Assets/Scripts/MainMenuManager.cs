using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainMenuManager : MonoBehaviour
{
    public string gameSceneName;

    public void StartGame()
    {
        Debug.Log("Entering the game...");
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameSceneName);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        Application.Quit();
    }
}
