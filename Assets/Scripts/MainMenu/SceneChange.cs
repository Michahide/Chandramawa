using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] GameObject SettingsPanel;
    [SerializeField] GameObject MenuPanel;
    public void Options() {
        if(SettingsPanel.activeInHierarchy){
            SettingsPanel.SetActive(false);
        } else if(!SettingsPanel.activeInHierarchy){
            SettingsPanel.SetActive(true);
        }
    }

    public void Exit(){
        Application.Quit();
    }


}
