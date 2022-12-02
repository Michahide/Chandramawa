using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNextScene : MonoBehaviour
{
    public void StartGame()
    {
        SceneLoaderManager.ProgressLoad("Start");
        Application.Quit();
    }

    public void exitgame()
    {
        Application.Quit();
    }
}
