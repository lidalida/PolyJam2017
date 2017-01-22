using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    public Sprite s1, s2, s3, s4, s5, s6;
	// Use this for initialization
	void Start () {
        if(PointsCounter.total_points<0.1)
            GetComponent<SpriteRenderer>().sprite = s1;
        else if (PointsCounter.total_points < 0.1)
            GetComponent<SpriteRenderer>().sprite = s2;
        else if (PointsCounter.total_points >= 0.1 && PointsCounter.total_points < 0.2)
            GetComponent<SpriteRenderer>().sprite = s3;
        else if (PointsCounter.total_points >= 0.2 && PointsCounter.total_points < 0.3)
            GetComponent<SpriteRenderer>().sprite = s4;
        else if (PointsCounter.total_points >= 0.3 && PointsCounter.total_points < 0.4)
            GetComponent<SpriteRenderer>().sprite = s5;
        else if (PointsCounter.total_points > 0.4)
            GetComponent<SpriteRenderer>().sprite = s6;

        transform.localScale = new Vector3(0.66f, 0.66f, 0);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
