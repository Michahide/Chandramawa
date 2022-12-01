using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairSystemArcade : MonoBehaviour
{
    [SerializeField] private PlayerController pControl;
    [SerializeField] private GameObject StairArcade;
    public bool isUnderStairArcade;
  
    
    // Start is called before the first frame update
    void Start()
    {
         StairArcade.SetActive(false);
         isUnderStairArcade = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isUnderStairArcade == false){
            Debug.Log("darari dadada");
            if(pControl.isJumping == true){
                Debug.Log("NGENTOT");
                StairArcade.SetActive(true);
            } else if(pControl.isGroundHard == true){
                StairArcade.SetActive(false);

            }
        }else if(isUnderStairArcade == true){ Debug.Log("WOI GINI");}

    }

   private void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            isUnderStairArcade = true;
        }
    }

   private void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            isUnderStairArcade = false;
        }
    }
}
