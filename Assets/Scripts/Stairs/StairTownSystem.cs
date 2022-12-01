using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairTownSystem : MonoBehaviour
{
    [SerializeField] private PlayerController pContr;
    [SerializeField] private GameObject Stair;
    public bool isUnderStair;
  
    
    // Start is called before the first frame update
    void Start()
    {
         Stair.SetActive(false);
         isUnderStair = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isUnderStair == false){
        if(pContr.isJumping == true){
            Stair.SetActive(true);
        } else if(pContr.isGroundHard == true){
            Stair.SetActive(false);

        }
        }else{
            if(pContr.isGroundHard == true){
            Stair.SetActive(false);}
        }

    }

    void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            isUnderStair = true;
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            isUnderStair = false;
        }
    }
}
