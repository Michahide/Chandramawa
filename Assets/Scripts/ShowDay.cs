using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDay : MonoBehaviour
{
    [SerializeField] private float begin;

    void Start()
    {
        StartCoroutine(Show(begin));
    }
    IEnumerator Show(float delay)
    {
        yield return new WaitForSeconds(delay);
        this.gameObject.SetActive(false);
    }
    
    IEnumerator Hide(float delay)
    {
        yield return new WaitForSeconds(delay);
        this.gameObject.SetActive(false);
    }
}
