using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsCounter : MonoBehaviour {

    public int pointsCounter = 0;
    double time, time_start;
	// Use this for initialization
	void Start () {
        time_start = (System.DateTime.Now - System.DateTime.Today).TotalSeconds;		
	}
	
	// Update is called once per frame
	void Update () {
        time = (System.DateTime.Now - System.DateTime.Today).TotalSeconds;
        if (time - time_start > 30)
            gameEnd();

	}

    public void AddPoints(int points)
    {
        pointsCounter += points;
    }

    private void gameEnd()
    {
        Application.LoadLevel("EndGameScene");
    }
}
