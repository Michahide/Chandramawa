using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNextScene : MonoBehaviour
{
    public void StartGame()
    {
        SceneLoaderManager.ProgressLoad("Start");
    }
    
    public void MainMenu()
    {
        SceneLoaderManager.ProgressLoad("MainMenu");
    }

    public void exitgame()
    {
        Application.Quit();
    }
}
