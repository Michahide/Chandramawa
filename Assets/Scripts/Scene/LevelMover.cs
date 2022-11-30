
using UnityEngine;

public class LevelMover : MonoBehaviour
{
    public string sceneName;


    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
                SceneLoaderManager.ProgressLoad(sceneName);

                this.gameObject.SetActive(false);
        }
    }
}
