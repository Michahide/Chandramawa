using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExitObjectDisabler : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other) {
        this.gameObject.SetActive(false);
    }
}
