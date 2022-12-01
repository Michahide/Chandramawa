using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpPlatformReach : MonoBehaviour
{
    [SerializeField] public UpPlatformSystem stairBool;
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
         
        if(!stairBool.stairBool){
            Debug.Log("TrueHard");
            stairBool.stairBool = true;
        }
        
        }
    }
}
