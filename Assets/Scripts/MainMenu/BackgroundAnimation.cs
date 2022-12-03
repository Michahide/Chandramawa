using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAnimation : MonoBehaviour
{
    [SerializeField] Animator Background;
    void Awake()
    {
        Appear();
        Disappear();
    }

    IEnumerator Appear()
    {
        Background.SetTrigger("BackgroundAppear");
        yield return new WaitForSeconds(0.8f);


    }
    IEnumerator Disappear()
    {
        Background.ResetTrigger("BackgroundAppear");
        yield return new WaitForSeconds(0.8f);
    }
}
