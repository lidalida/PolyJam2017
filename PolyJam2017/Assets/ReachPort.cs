using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachPort : MonoBehaviour {

    public Transform controller;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ships")
        {
            other.transform.GetComponent<ShipController>().SetDirection(1);
            other.tag = "Port";
            controller.GetComponent<PointsCounter>().AddPoints(1);
        }
    }
}
