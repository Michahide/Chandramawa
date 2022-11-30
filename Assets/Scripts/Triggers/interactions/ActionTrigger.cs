using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTrigger : MonoBehaviour
{
    [SerializeField] private SceneAction sceneAction = null;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sceneAction.GetActionIcon();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
                sceneAction.Interact();

                this.gameObject.SetActive(false);
        }
    }
}
