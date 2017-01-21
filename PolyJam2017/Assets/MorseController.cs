using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorseController : MonoBehaviour {

    const float dot = 0.2f;
    const float kreska = 1f;

    bool[] signal = new bool[3];
    int thickCounter = 0;

    float lastTimeAction = 0;
    float pauseTime = -2;
    bool isKeyDown = false;

    public Sprite s1, s2;

    List<GameObject> dots = new List<GameObject>();

    // Use this for initialization
    void Start () {
        for(int i = 0;i< signal.Length;i++)
            signal[i] = false;

        lastTimeAction = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        resetPause();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isKeyDown = true;
            resolveThick();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isKeyDown = false;
            resolveThick();
        }

        GameObject instance;
        if (isKeyDown)
        {
            instance = (GameObject)Instantiate(Resources.Load("Prefabs/MorseDot"), new Vector3(5.5f, -4f, 0f), new Quaternion(0, 0, 0, 0));
            instance.GetComponent<Rigidbody2D>().velocity = Vector2.left*2;
            dots.Add(instance);
        }

        reset();
        resolveSignal();
    }

    void resetPause()
    {
        if (pauseTime + 2 > Time.time || pauseTime==0)
            return;
        pauseTime = 0;
        GetComponent<SpriteRenderer>().sprite = s1;
    }

    void reset()
    {
        if (isKeyDown)
        {
            if (lastTimeAction + kreska < Time.time)
            {
                clearSignal();
                qualifyDots(2);
            }
        }
        else if(thickCounter!=0)
            if (lastTimeAction + 2 < Time.time)
            {
                clearSignal();
                qualifyDots(2);
            }
    }

    void resolveThick()
    {
        if(!isKeyDown)
            if (lastTimeAction + dot > Time.time)
                signal[thickCounter++] = true;
            else if (lastTimeAction + kreska > Time.time)
                signal[thickCounter++] = false;
        lastTimeAction = Time.time;
    }

    void clearSignal()
    {
        if (thickCounter < 3)
        {
            GetComponent<SpriteRenderer>().sprite = s2;
            pauseTime = Time.time;
        }
        for (int i = 0; i < signal.Length; i++)
            signal[i] = false;
        thickCounter = 0;
    }

    void resolveSignal()
    {
        if (thickCounter >= 3)
        {
            if (signal[2])
                if (signal[1])
                    if (signal[0])
                        Debug.Log("N");
                    else
                        Debug.Log("S");
                else
                    if (signal[0])
                    Debug.Log("E");
                else
                    Debug.Log("W");
            else
                if (signal[1])
                if (signal[0])
                    Debug.Log("NE");
                else
                    Debug.Log("SW");
            else
                    if (signal[0])
                Debug.Log("SE");
            else
                Debug.Log("NW");
            clearSignal();
            qualifyDots(1);
        }
    }

    void qualifyDots(int cid)
    {
        for (int i = 0; i < dots.Count; i++)
        {
            dots[i].GetComponent<LifetimeController>().enabled = true;
            if (cid == 1)
                dots[i].GetComponent<LifetimeController>().isGood = true;
            else
                dots[i].GetComponent<LifetimeController>().isGood = false;
            dots[i].GetComponent<Rigidbody2D>().velocity = Vector3.up*0.5f;
        }
        dots.Clear();
    }
}
