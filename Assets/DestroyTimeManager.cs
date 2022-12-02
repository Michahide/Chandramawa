using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimeManager : MonoBehaviour

{
    public TimeManager timeManager;
    // Start is called before the first frame update
    void Start()
    {
        timeManager = GetComponent<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeManager == null){
            Destroy(this.gameObject);
        }
    }
}
