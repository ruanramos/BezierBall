﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadFreePlay()
    {
        SceneManager.LoadScene("FreePlay");
    }

    public void LoadTimeAtack()
    {
        SceneManager.LoadScene("Scene2");
    }
}
