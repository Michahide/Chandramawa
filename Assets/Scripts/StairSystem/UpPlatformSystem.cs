using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpPlatformSystem : MonoBehaviour
{
    [SerializeField] public bool stairBool;
    [SerializeField] private PlayerController pContr;
    [SerializeField]private GameObject platform;
    // Start is called before the first frame update
    void Start()
    {
        stairBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(stairBool){
         
           platform.SetActive(true);
        }
        else if(!stairBool){

             platform.SetActive(false);
        }

        if (pContr.isGroundHard == true)
        {
            stairBool = false;
        }
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player")
        {
           
            if(stairBool){ 
                Debug.Log("False");
            stairBool = false;
        }
        else if(!stairBool){
            Debug.Log("True");
            stairBool = true;
        }
        
        }
    }
}
