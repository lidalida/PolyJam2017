using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesSpawner : MonoBehaviour {

    float lastSpawnTime;

	// Use this for initialization
	void Start () {
        lastSpawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        GameObject instance;
        if (lastSpawnTime + 0.2f < Time.time)
        {
            for(int i = 0; i < 3; i++)
            {
                if (Random.Range(0, 1f) < 0.5f)
                    instance = (GameObject)Instantiate(Resources.Load("Prefabs/Fala1"), new Vector3(Random.Range(-12, 12), Random.Range(-10, 10), 0f), new Quaternion(0, 0, 0, 0));
                else
                    instance = (GameObject)Instantiate(Resources.Load("Prefabs/Fala2"), new Vector3(Random.Range(-12, 12), Random.Range(-10, 10), 0f), new Quaternion(0, 0, 0, 0));
                instance.transform.position = new Vector3(Random.Range(-12f, 12f), Random.Range(-10f, 10f), 0f);
            }
            lastSpawnTime = Time.time;
        }
	}
}
