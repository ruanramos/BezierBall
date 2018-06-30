using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour {

    public AudioClip[] musics;
    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = this.gameObject.GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
		if(SceneManager.GetActiveScene().name != "Menu")
        {
            audioSource.clip = musics[0];
            audioSource.loop = true;
            audioSource.Play();
        }
        else
        {
            int i = 1;
            audioSource.clip = musics[i];
            audioSource.loop = false;
            if (!audioSource.isPlaying) i = i % 2 + 1;
            audioSource.Play();
        }
	}
}
