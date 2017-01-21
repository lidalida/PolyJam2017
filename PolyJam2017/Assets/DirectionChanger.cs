using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionChanger : MonoBehaviour {

    public List<Collider2D> shipsOnTarget = new List<Collider2D>();
    public int lol = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        foreach (Collider2D col in shipsOnTarget)
            if (col.tag != "Ships")
            {
                shipsOnTarget.Remove(col);
                break;
            }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Ships")
            shipsOnTarget.Add(other);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ships")
            shipsOnTarget.Remove(other);
    }

    public void changeDirections(int dir)
    {
        for (int i = 0; i < shipsOnTarget.Count; i++)
            shipsOnTarget[i].transform.GetComponent<ShipController>().SetDirection(dir);
    }
}
