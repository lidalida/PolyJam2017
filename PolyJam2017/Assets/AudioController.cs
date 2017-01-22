using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public AudioSource source;
    AudioClip clip;

    int clipsCounter = 0;
    int[] actualClips;
    public float[] actualTimes;
    public float[] actualLengths;

    // Use this for initialization
    void Start () {
        actualClips = new int[2];
        actualTimes = new float[2];
        actualLengths = new float[2];
    }
	
	// Update is called once per frame
	void Update () {
        if (Random.Range(0, 10000) < 20)
        {
            if(TakeRandomClip())
                source.PlayOneShot(clip);
            clipsCounter++;
        }
        ResetClips();
    }

    bool TakeRandomClip()
    {
        int rnd = Random.Range(0, 1000);
        if (rnd < 650)
        {
            if (!CheckClips(1))
                return false;
            if (ActualizeClipsTable(1))
            {
                clip = (AudioClip)Resources.Load("Audio/maui3");
                ActualizeTimes(1,Time.time,clip.length);
            }
            else
                return false;
        }
        else if (rnd < 700)
        {
            if (!CheckClips(2))
                return false;
            if (ActualizeClipsTable(2))
            {
                clip = (AudioClip)Resources.Load("Audio/mauichoir");
                ActualizeTimes(2, Time.time, clip.length);
            }
            else
                return false;
        }
        else if (rnd < 750)
        {
            if (!CheckClips(3))
                return false;
            if (ActualizeClipsTable(3))
            {
                clip = (AudioClip)Resources.Load("Audio/mauichoir2");
                ActualizeTimes(3, Time.time, clip.length);
            }
            else
                return false;
        }
        else if (rnd < 800)
        {
            if (!CheckClips(4))
                return false;
            if (ActualizeClipsTable(4))
            {
                clip = (AudioClip)Resources.Load("Audio/mauichoir3");
                ActualizeTimes(4, Time.time, clip.length);
            }
            else
                return false;
        }
        else if (rnd < 850)
        {
            if (!CheckClips(5))
                return false;
            if (ActualizeClipsTable(5))
            {
                clip = (AudioClip)Resources.Load("Audio/wielorybnicy");
                ActualizeTimes(5, Time.time, clip.length);
            }
            else
                return false;
        }
        else if (rnd < 900)
        {
            if (!CheckClips(6))
                return false;
            if (ActualizeClipsTable(6))
            {
                clip = (AudioClip)Resources.Load("Audio/wielorybnicy2");
                ActualizeTimes(6, Time.time, clip.length);
            }
            else
                return false;
        }
        else if (rnd < 950)
        {
            if (!CheckClips(7))
                return false;
            if (ActualizeClipsTable(7))
            {
                clip = (AudioClip)Resources.Load("Audio/wielorybnicy3");
                ActualizeTimes(7, Time.time, clip.length);
            }
            else
                return false;
        }
        else
        {
            if (!CheckClips(8))
                return false;
            if (ActualizeClipsTable(8))
            {
                clip = (AudioClip)Resources.Load("Audio/wielorybnicy4");
                ActualizeTimes(8, Time.time, clip.length);
            }
            else
                return false;
        }
        return true;
    }

    bool CheckClips(int id)
    {
        for (int i = 0; i < actualClips.Length; i++)
        {
            if (actualClips[i] == id)
                return false;
        }
        return true;
    }

    bool ActualizeClipsTable(int id)
    {
        for (int i = 0; i < actualClips.Length; i++)
        {
            if (actualClips[i] == 0)
            {
                actualClips[i] = id;
                return true;
            }
        }
        return false;
    }

    void ActualizeTimes(int id, float time, float length)
    {
        for (int i = 0; i < actualClips.Length; i++)
        {
            if (actualClips[i] == id)
            {
                actualTimes[i] = time;
                actualLengths[i] = length;
                return;
            }
        }
    }

    void ResetClips()
    {
        for (int i = 0; i < actualTimes.Length; i++)
        {
            if(actualTimes[i] + actualLengths[i] < Time.time)
            {
                actualTimes[i] = 0;
                actualLengths[i] = 0;
                actualClips[i] = 0;
            }
        }
    }
}
