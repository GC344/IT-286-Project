using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPress : MonoBehaviour {
    public bool isPressed;
    public Material greenLight;
	// Use this for initialization
	void Start () {
        isPressed = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision collision)
    {
        if (!isPressed)
        {
            transform.position -= new Vector3(0f, 0.03f, 0f);
            isPressed = true;
            GetComponent<Renderer>().material = greenLight;

            Debug.Log("Switch Pressed");
        }
    }
}
