using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsCounter : MonoBehaviour {

    public int pointsCounter = 0;
    static public float total_points;
    double time, time_start;
	// Use this for initialization
	void Start () {
        pointsCounter = 0;
        time_start = (System.DateTime.Now - System.DateTime.Today).TotalSeconds;		
	}
	
	// Update is called once per frame
	void Update () {
        time = (System.DateTime.Now - System.DateTime.Today).TotalSeconds;
        if (time - time_start > 60)
            gameEnd();


        if (Input.GetKeyDown(KeyCode.W))
        {
            pointsCounter = GetComponent<SpawnShips>().total_ships_spawned;
            gameEnd();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            pointsCounter = 0;
            gameEnd();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            pointsCounter = GetComponent<SpawnShips>().total_ships_spawned/3;
            gameEnd();
        }

	}

    public void AddPoints(int points)
    {
        pointsCounter += points;
    }

    private void gameEnd()
    {
        total_points = (float)pointsCounter / GetComponent<SpawnShips>().total_ships_spawned;
        Application.LoadLevel("EndGameScene");
    }
}
