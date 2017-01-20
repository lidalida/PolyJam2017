using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotating : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        rotate();
	}

    private void rotate()
    {
        Vector3 mousePositionVector3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        mousePositionVector3 = Camera.main.ScreenToWorldPoint(mousePositionVector3);
        Vector3 targetdir = mousePositionVector3 - transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetdir);
    }
}
