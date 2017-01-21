using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commons : MonoBehaviour {

    public float height, width;
    public float ship_height = 1.5f, ship_width = 2;
	// Use this for initialization
	void Start () {
        height = 2 * Camera.main.orthographicSize;
        width=height * Camera.main.aspect;
        Debug.Log(height + " " + width);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
