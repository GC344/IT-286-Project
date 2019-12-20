using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour {
    private int frameCount;
    public int flickerOnFrame, hiddenForFrames;
    public GameObject objectToFlicker;
 	// Use this for initialization
	void Start () {
        frameCount = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        frameCount += 1;

        if ((frameCount == flickerOnFrame) && isActiveAndEnabled)
        {
            objectToFlicker.SetActive(false);
            frameCount = 0;
        }
        else
        {
            hiddenForFrames -= 1;
            if (hiddenForFrames == 0)
            {
                objectToFlicker.SetActive(true);
            }
            
        }
      
        //transform.gameObject.SetActive(true);

/*
 *  if (frameCount == flickerOnFrame + hiddenForFrames)
{
    transform.gameObject.SetActive(true);
    frameCount = 0;
}
*/

Debug.Log(frameCount);
}
}
