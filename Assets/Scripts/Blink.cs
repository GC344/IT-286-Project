using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {

    public float timeOut,timeIn,delay;
    public GameObject blinkThis;

	// Use this for initialization
	void Start () {
        StartCoroutine(Bloop());
	}
	
	// Update is called once per frame
	void Update () {
       InvokeRepeating("Bloop", 0, 0.4f);

    }
    IEnumerator Bloop()
    {
        yield return new WaitForSeconds(delay);
        blinkThis.SetActive(false);
        yield return new WaitForSeconds(timeOut);
        blinkThis.SetActive(true);
        yield return new WaitForSeconds(timeIn);
        Start();

    }
}
