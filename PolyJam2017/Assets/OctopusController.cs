using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusController : MonoBehaviour {

    float lastSecBeforeDie;
    float birthTime;

	// Use this for initialization
	void Start () {
        lastSecBeforeDie = 0;
        birthTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if(birthTime+10f<Time.time)
        {
            prepereToDie();
        }
        if (lastSecBeforeDie == 0)
            return;
        if (lastSecBeforeDie + 1.5f < Time.time)
            Destroy(gameObject);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ships")
        {
            if(lastSecBeforeDie==0)
                prepereToDie();
        }
    }

    void prepereToDie()
    {
        GetComponent<Animator>().SetBool("destroyed", true);
        lastSecBeforeDie = Time.time;
        birthTime = Time.time;
    }
}
