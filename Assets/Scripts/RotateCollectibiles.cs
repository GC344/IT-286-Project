using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCollectibiles : MonoBehaviour {
    //for each child in collectibles rotate them
    // Use this for initialization
   // public GameObject collectibles;
   public float rate;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Transform childObjects in this.transform)
        {
            childObjects.transform.Rotate(0f, Time.deltaTime * rate, 0f, Space.Self); 
        }
            
    }
}
