using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainMenuManager : MonoBehaviour
{
    public string gameSceneName;

    public GameObject mainMenuPanel;
    public GameObject settingsPanel;
    public SettingsMenu settingsMenu;

    private void Start()
    {
        if (mainMenuPanel == null || settingsPanel == null || settingsMenu == null)
        {
            Debug.LogError("Menu panels not set!");
        }
    }

    public void StartGame()
    {
        Debug.Log("Entering the game...");
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameSceneName);
    }

    public void OpenSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void ExitSettings()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void SaveAndExitSettings()
    {
        settingsMenu.SaveSettings();
        ExitSettings();
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        Application.Quit();
    }
}
