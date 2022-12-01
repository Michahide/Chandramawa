using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunicationManager : MonoBehaviour
{
    private DialogueControls dialogueControls;
    private GameObject dialogueContainer;
    private GameObject options;
    public int npcCom;

    void Start()
    {
        dialogueControls = FindObjectOfType<DialogueControls>();

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (options)
        {
            npcCom = dialogueControls.npc;
        }
        else
        {
            Debug.Log("no Options");
        }
    }
}
