using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTriggerCollider : MonoBehaviour
{
    [SerializeField] private SceneAction sceneAction = null;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sceneAction.GetActionIcon();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sceneAction.Interact();

        this.gameObject.SetActive(false);
    }

 }
