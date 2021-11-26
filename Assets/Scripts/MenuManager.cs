using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuManager : MonoBehaviour
{
    public string mainMenuSceneName;
    public string gameSceneName;

    public GameObject menuPanel;
    public GameObject settingsPanel;
    public GameObject highScorePanel;
    public SettingsMenu settingsMenu;

    private AudioSource menuAudio;
    public AudioClip menuSound;

    private void Start()
    {
        if (menuPanel == null || settingsPanel == null || settingsMenu == null)
        {
            Debug.LogError("Menu panels not set!");
        }
    }

    public void StartGame()
    {
        Debug.Log("Entering the game...");
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameSceneName);
        //menuAudio.PlayOneShot(menuSound, 1.0f);
    }

    public void OpenSettings()
    {
        menuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void ExitSettings()
    {
        settingsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void SaveAndExitSettings()
    {
        settingsMenu.SaveSettings();
        ExitSettings();
    }
    public void OpenHighScores()
    {
        menuPanel.SetActive(false);
        highScorePanel.SetActive(true);
    }

    public void ExitHighScores()
    {
        highScorePanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        //menuAudio.PlayOneShot(menuSound, 1.0f);
        Application.Quit();
    }

    public void OpenMenu()
    {
        if (menuPanel.activeSelf == false && settingsPanel.activeSelf == false)
        {
            menuPanel.SetActive(true);
        }
    }

    public void ExitToMainMenu()
    {
        Debug.Log("Exiting to main menu...");
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenuSceneName);
    }
}
