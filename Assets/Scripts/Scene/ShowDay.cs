using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDay : MonoBehaviour
{
    [SerializeField] private float begin = 0;
    [SerializeField] private float close = 0;
    [SerializeField] GameObject panel;

    void Start()
    {
        StartCoroutine(Show(begin));
        StartCoroutine(Hide(close));
    }
    IEnumerator Show(float show)
    {
        yield return new WaitForSeconds(show);
        this.panel.SetActive(true);
    }
    
    IEnumerator Hide(float hide)
    {
        yield return new WaitForSeconds(hide);
        this.panel.SetActive(false);
    }
}
