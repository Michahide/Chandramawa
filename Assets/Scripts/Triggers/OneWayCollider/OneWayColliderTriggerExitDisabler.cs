using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayColliderTriggerExitDisabler : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        this.gameObject.SetActive(false);
    }
}
