using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave1Lifetime : MonoBehaviour {

    float birthTime;

	// Use this for initialization
	void Start () {
        birthTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (birthTime + 1.3f < Time.time)
            Destroy(gameObject);
	}
}
