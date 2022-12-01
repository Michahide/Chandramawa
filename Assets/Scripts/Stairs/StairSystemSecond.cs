using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairSystemSecond : MonoBehaviour
{
   [SerializeField] private StairsSystem stairBool;
    
    // [SerializeField]private GameObject masking2;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player")
        {
           
            if(stairBool.stairBool){ 
                Debug.Log("False");
                stairBool.stairBool = false;
            }
      
        }
    }
}
