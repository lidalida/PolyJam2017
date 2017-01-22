using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusSpawner : MonoBehaviour {

    float lastSpawnTime;

	// Use this for initialization
	void Start () {
        lastSpawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        GameObject instance;
		if(lastSpawnTime + 10f < Time.time)
        {
            instance = (GameObject)Instantiate(Resources.Load("Prefabs/Osmiornica"), new Vector3(Random.Range(-12, 12), Random.Range(-10, 10), 0f), new Quaternion(0, 0, 0, 0));
            lastSpawnTime = Time.time;
        }
	}
}
