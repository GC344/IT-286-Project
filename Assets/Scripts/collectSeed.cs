using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectSeed : MonoBehaviour {
    private float refToNumSeeds = RollTheBall.seedMoney;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter detected with " + other + " and " + gameObject);
        Destroy(gameObject);
        RollTheBall.seedMoney += 1;
    }
}
