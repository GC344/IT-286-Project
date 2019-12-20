using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnPlate : MonoBehaviour {

    // Use this for initialization
    public float spinSpeed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        
           transform.Rotate(0f, Time.deltaTime * spinSpeed, 0f, Space.Self);
        

    }
}
