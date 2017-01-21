using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Codes : MonoBehaviour {
    bool go = false;
    private float startTime;
    private float journeyLength;
    public int speed = 20;
    Vector3 up, down, destination, start_position;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        down = new Vector3(0, -20, 0);
        up = new Vector3(0, 0, 0);
        journeyLength = Vector3.Distance(up, down);
        destination = down;
        start_position = down;

	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position == destination)
        {
            go = false;
        }
        if (Input.GetMouseButtonDown(1) && destination!=up)
        {
            go = true;
            destination = up;

            startTime = Time.time;
            start_position=transform.position;
            journeyLength = Vector3.Distance(start_position, destination);
            

        }
        else if (Input.GetMouseButtonDown(1) && destination==up)
        {
            go = true;
            destination = down;

            startTime = Time.time;
            start_position = transform.position;
            journeyLength = Vector3.Distance(start_position, destination);
            

        }

        if(go)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;            
            gameObject.transform.position = Vector3.Lerp(start_position, destination, fracJourney);
        }       
       
		
	}
}
