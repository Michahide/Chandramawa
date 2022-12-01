using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsSystem : MonoBehaviour
{
   
    [SerializeField] public bool stairBool;
    
    [SerializeField]private GameObject masking;
    // Start is called before the first frame update
    void Start()
    {
        stairBool = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(stairBool){
         
           masking.SetActive(true);
        }
        else if(!stairBool){

             masking.SetActive(false);
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
