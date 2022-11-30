using UnityEngine;

public class SceneLoaderManager : MonoBehaviour
{

    //load
    public static void Load(string sceneName)
    {
        SceneLoader.Load(sceneName);
    }

    //Progress Load
    public static void ProgressLoad(string sceneName)
    {
        SceneLoader.ProgressLoad(sceneName);
    }

    //ReloadLevel
    //public static void ReloadLevel()
    //{
    //    SceneLoader.ReloadLevel();
    //}

    //// LoadNextLevel
    //public static void LoadNextLevel()
    //{
    //    SceneLoader.LoadNextLevel();
    //}

    // Quit
    public static void QuitGame()
    {
        SceneLoader.Quit();
    }
}