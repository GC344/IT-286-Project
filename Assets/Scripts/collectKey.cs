using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectKey : MonoBehaviour {      
        //private float refToTopSpeed = RollTheBall.topSpeed;

        void OnTriggerEnter(Collider other)
        {
            Debug.Log("OnTriggerEnter detected with " + other + " and " + gameObject);
            Destroy(gameObject);
            //RollTheBall.topSpeed += 0.5f;
        }
    
}
