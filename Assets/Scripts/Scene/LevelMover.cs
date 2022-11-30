
using UnityEngine;

public class LevelMover : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Masuk");
            SceneLoaderManager.ProgressLoad(sceneName);
        }
    }
}
