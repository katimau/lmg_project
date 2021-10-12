using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainMenuManager : MonoBehaviour
{
    public string GameSceneName;
    UnityEngine.SceneManagement.Scene gameScene;
    // Start is called before the first frame update
    void Start()
    {
        //gameScene = SceneManaget.GetSceneByName(GameSceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        Debug.Log("Entering the game...");
        UnityEngine.SceneManagement.SceneManager.LoadScene(GameSceneName);
    }

    public void QuitGame(){
        Debug.Log("Quitting the game...");
        Application.Quit();
    }
}
