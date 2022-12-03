using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSwitchScene : MonoBehaviour
{
    [SerializeField] private float nextScene = 0;
    [SerializeField] private string SceneAfterCutScene = "";

    void Start()
    {
        StartCoroutine(NextScene(nextScene));
    }

    IEnumerator NextScene(float next)
    {
        yield return new WaitForSeconds(next);
        SceneManager.LoadScene(SceneAfterCutScene);

    }
}
