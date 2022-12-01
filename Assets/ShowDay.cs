using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDay : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ShowAndHide(3));
    }
    IEnumerator ShowAndHide(float delay)
    {
        yield return new WaitForSeconds(delay);
        this.gameObject.SetActive(false);
    }
}
