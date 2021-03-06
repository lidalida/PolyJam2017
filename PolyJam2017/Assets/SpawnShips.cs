﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShips : MonoBehaviour {

    GameObject spawned;
    public int ships_counter;
    public int total_ships_spawned;
    public int max_ships=12;

	// Use this for initialization
	void Start () {
        ships_counter=1;
        total_ships_spawned = 1;
        InvokeRepeating("singleSpawn", 1.0f, 5f);
	}
	
	// Update is called once per frame
	void Update () {

	}

    void singleSpawn()
    {
        if (ships_counter < max_ships)
        {
            float height = GetComponent<Commons>().height;
            float width = GetComponent<Commons>().width;
            float ship_height = GetComponent<Commons>().ship_height;
            float ship_width = GetComponent<Commons>().ship_width;
            int rnd = (int)Random.Range(0, 3);
            int dir = (int)Random.Range(0, 3);
            if (rnd == 0)
            {
                float up = height / 2 + ship_width;
                Vector3 pos = new Vector3(Random.Range(-width / 2 + 2*ship_width, width / 2 - 2*ship_width), up, 0);
                spawned = (GameObject)Instantiate(Resources.Load("Prefabs/Ship"), pos, Quaternion.identity);
                if (dir == 0)
                    spawned.GetComponent<ShipController>().SetDirection(2);
                else if (dir == 1)
                    spawned.GetComponent<ShipController>().SetDirection(3);
                else if (dir == 2)
                    spawned.GetComponent<ShipController>().SetDirection(4);
            }
            else if (rnd == 1)
            {
                float down = -height / 2 - ship_width;
                Vector3 pos = new Vector3(Random.Range(-width / 2 + 2*ship_width, width / 2 - 2*ship_width), down, 0);
                spawned = (GameObject)Instantiate(Resources.Load("Prefabs/Ship"), pos, Quaternion.identity);
                if (dir == 0)
                    spawned.GetComponent<ShipController>().SetDirection(6);
                else if (dir == 1)
                    spawned.GetComponent<ShipController>().SetDirection(7);
                else if (dir == 2)
                    spawned.GetComponent<ShipController>().SetDirection(0);

            }           
            else if (rnd == 2)
            {
                float right = width / 2 + ship_width;
                Vector3 pos = new Vector3(right, Random.Range(-height / 2 + 2*ship_width, height / 2 - 2*ship_width), 0);
                spawned = (GameObject)Instantiate(Resources.Load("Prefabs/Ship"), pos, Quaternion.identity);
                if (dir == 0)
                    spawned.GetComponent<ShipController>().SetDirection(0);
                else if (dir == 1)
                    spawned.GetComponent<ShipController>().SetDirection(1);
                else if (dir == 2)
                    spawned.GetComponent<ShipController>().SetDirection(2);


            }
            ships_counter++;
            total_ships_spawned++;
            Debug.Log(ships_counter);
        }
    }
}
