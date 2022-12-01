using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropdownTest : MonoBehaviour
{
    [SerializeField] TMP_Dropdown dropd;

    private void Start()
    {

    }

    public void GetOption(int value)
    {
        Debug.Log(dropd.options[value].text);
    }
}
