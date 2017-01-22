﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void LoadGameScene()
    {
        Application.LoadLevel("Gamescene");
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void Credits()
    {
        Application.LoadLevel("CreditsScene");
    }
}
