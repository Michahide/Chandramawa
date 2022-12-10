using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour
{
    private bool TriggerEnter = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerEnter = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TriggerEnter = false;
    }

    private void Update()
    {
        if(TriggerEnter == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E Pressed");
                this.gameObject.SetActive(false);
            }
        }
    }
}