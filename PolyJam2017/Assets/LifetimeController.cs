using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifetimeController : MonoBehaviour {

    float birthTime;
    float changeTime;

    public bool isGood;
    public Sprite dot1, dot2, dot3;
    bool color;

    // Use this for initialization
    void OnEnable () {
        birthTime = Time.time;
        changeTime = Time.time;
        color = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (changeTime + 0.1f < Time.time && !color)
        {
            if (isGood)
                GetComponent<SpriteRenderer>().sprite = dot2;
            else
                GetComponent<SpriteRenderer>().sprite = dot3;
            changeTime = Time.time;
            color = true;
        }
        else if (changeTime + 0.25f < Time.time && color)
        {
            GetComponent<SpriteRenderer>().sprite = dot1;
            changeTime = Time.time;
            color = false;
        }

        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = Mathf.Lerp(1, 0, Mathf.Pow((Time.time - birthTime),0.3f));
        GetComponent<SpriteRenderer>().color = tmp;

        if (birthTime + 1.0f < Time.time)
            Destroy(gameObject);
	}
}
