using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void Play() {
        SceneManager.LoadScene("DummyScene");
    }
    public void ToMainMenu(){
       SceneManager.LoadScene("MainMenu");
    }
    public void Exit() {
        Application.Quit();
    }
}
