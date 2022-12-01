using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTest : MonoBehaviour
{

    public void OnVolumeChanged(string value)
    {
        Debug.Log("Volume: " + value);
    }

    public void print (bool value)
    {
        if (value)
        {
            Debug.Log("Mute");
        }
        else
        {
            Debug.Log("Unmute");
        }
    }
}
