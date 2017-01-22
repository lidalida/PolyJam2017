using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    public int direction = 0;
    bool dirUpToDate = false;
    public float speed;
    public Sprite n, ne, e, se, s, sw, w, nw;
    public Sprite kn, kne, ke, kse, ks, ksw, kw, knw;
    Transform kilwater;
    Vector3 targetPos;
    Vector3 lastPos;
    float secondsFromDie;
    public RuntimeAnimatorController ton;
    GameObject controller;
    AudioClip clip;


	// Use this for initialization
	void Awake () {
        secondsFromDie = 0;
        kilwater = transform.GetChild(0);
        controller = GameObject.Find("GameController");

	}
	
	// Update is called once per frame
	void Update () {
        if(secondsFromDie == 0)
        {
            SetDirection(direction);
        }
        else
        {
            transform.position = Vector3.Lerp(lastPos, targetPos, (Time.time - secondsFromDie) / 1.5f);
            if (secondsFromDie + 1.5f < Time.time)
            {
                Destroy(gameObject);
                controller.GetComponent<SpawnShips>().ships_counter--;
                Debug.Log(controller.GetComponent<SpawnShips>().ships_counter);
            }
        }
	}

    public void SetDirection(int dir)
    {
        direction = dir;
        switch (direction)
        {
            case 7:
                GetComponent<Rigidbody2D>().velocity = Vector2.up;
                break;
            case 6:
                GetComponent<Rigidbody2D>().velocity = Vector2.up*Mathf.Sqrt(2) + Vector2.right*Mathf.Sqrt(2);
                break;
            case 5:
                GetComponent<Rigidbody2D>().velocity = Vector2.right;
                break;
            case 4:
                GetComponent<Rigidbody2D>().velocity = Vector2.down * Mathf.Sqrt(2) + Vector2.right * Mathf.Sqrt(2);
                break;
            case 3:
                GetComponent<Rigidbody2D>().velocity = Vector2.down;
                break;
            case 2:
                GetComponent<Rigidbody2D>().velocity = Vector2.down * Mathf.Sqrt(2) + Vector2.left * Mathf.Sqrt(2);
                break;
            case 1:
                GetComponent<Rigidbody2D>().velocity = Vector2.left;
                break;
            case 0:
                GetComponent<Rigidbody2D>().velocity = Vector2.up * Mathf.Sqrt(2) + Vector2.left * Mathf.Sqrt(2);
                break;
            default:
                break;
        }
        GetComponent<Rigidbody2D>().velocity *= speed;
        SetRotation();
    }

    void SetRotation()
    {
        switch(direction)
        {
            case 7:
                GetComponent<SpriteRenderer>().sprite = n;
                kilwater.GetComponent<SpriteRenderer>().sprite = kn;
                GetComponent<Animator>().SetInteger("direction", 7);
                break;
            case 6:
                GetComponent<SpriteRenderer>().sprite = ne;
                kilwater.GetComponent<SpriteRenderer>().sprite = kne;
                GetComponent<Animator>().SetInteger("direction", 6);
                break;
            case 5:
                GetComponent<SpriteRenderer>().sprite = e;
                kilwater.GetComponent<SpriteRenderer>().sprite = ke;
                GetComponent<Animator>().SetInteger("direction", 5);
                break;
            case 4:
                GetComponent<SpriteRenderer>().sprite = se;
                kilwater.GetComponent<SpriteRenderer>().sprite = kse;
                GetComponent<Animator>().SetInteger("direction", 4);
                break;
            case 3:
                GetComponent<SpriteRenderer>().sprite = s;
                kilwater.GetComponent<SpriteRenderer>().sprite = ks;
                GetComponent<Animator>().SetInteger("direction", 3);
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = sw;
                kilwater.GetComponent<SpriteRenderer>().sprite = ksw;
                GetComponent<Animator>().SetInteger("direction", 2);
                break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = w;
                kilwater.GetComponent<SpriteRenderer>().sprite = kw;
                GetComponent<Animator>().SetInteger("direction", 1);
                break;
            case 0:
                GetComponent<SpriteRenderer>().sprite = nw;
                kilwater.GetComponent<SpriteRenderer>().sprite = kw;
                GetComponent<Animator>().SetInteger("direction", 0);
                break;
            default:
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag=="Octopus" || other.tag == "Ships")
        {
            ShipCrashSound();
            GetComponent<Animator>().runtimeAnimatorController = ton;
            if (other.tag == "Octopus")
                other.tag = "Port";
            if (direction > 3)
                GetComponent<SpriteRenderer>().flipX = true;
            direction = 8;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            secondsFromDie = Time.time;
            targetPos = other.transform.position;
            lastPos = transform.position;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag=="MainCamera")
        {
            Destroy(gameObject);
            controller.GetComponent<SpawnShips>().ships_counter--;
        }
    }

    void ShipCrashSound()
    {
        clip = (AudioClip)Resources.Load("Audio/zderzenie");
        controller.GetComponent<AudioSource>().PlayOneShot(clip);

    }
}
