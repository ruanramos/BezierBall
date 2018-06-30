using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour {

    public int totalScore;
    public float totalTime;
    public int scorePerArch = 1000;

    GameObject scoreText;
    GameObject timeText;

    GameObject ballCamera;
    GameObject mainCamera;
    GameObject globalCamera;

    GameObject menuButton;
    GameObject watcher;

    // Use this for initialization
    void Start () {
        totalScore = 0;
        totalTime = 0;

        scoreText = GameObject.Find("ScoreText");
        timeText = GameObject.Find("TimeText");
        ballCamera = GameObject.Find("BallCamera");
        globalCamera = GameObject.Find("GlobalCamera");
        mainCamera = GameObject.Find("Main Camera");
        watcher = GameObject.Find("Watcher");
        menuButton = GameObject.Find("MenuButton");
    }
	
	// Update is called once per frame
	void Update () {
        if(SceneManager.GetActiveScene().name == "Scene2")
        {
            Camera[] cameras = Resources.FindObjectsOfTypeAll<Camera>();
            for (int i = 0; i < cameras.Length; i++)
            {
                if (((cameras[i].name == "Main Camera" && cameras[i].gameObject.activeSelf) || (cameras[i].name == "GlobalCamera" && cameras[i].gameObject.activeSelf))
                    && menuButton.activeSelf)
                {
                    totalTime += Time.deltaTime;
                }
                timeText.GetComponent<Text>().text = "Time Passed: " + (int)totalTime + " secs";
            }
            GameObject.Find("ScoreText").GetComponent<Text>().text = "score: " + watcher.GetComponent<GameFlow>().totalScore;

            if (Input.GetKeyDown(KeyCode.R))
            {
                ResetLevel();
            }
        }        
    }

    public void GameOver()
    {
        Text[] texts = Resources.FindObjectsOfTypeAll<Text>();
        for (int i = 0; i < texts.Length; i++)
        {
            if(texts[i].name == "FinalText")
            {
                texts[i].gameObject.transform.parent.gameObject.SetActive(true);
            }
            if (texts[i].name == "GameOverText" && !GameObject.Find("Player").GetComponent<MeshRenderer>().enabled)
            {
                texts[i].gameObject.GetComponent<Text>().text = "Colision";
            }

        }
        if (SceneManager.GetActiveScene().name == "Scene2")
        {
            if ((int)totalScore - totalTime >= 0)
                GameObject.Find("FinalText").GetComponent<Text>().text = "Your Score: " + totalScore + "\nYour Time: " + (int)totalTime + " secs\nFinalScore: " + (int)(totalScore - totalTime);
            else
                GameObject.Find("FinalText").GetComponent<Text>().text = "Your Score: " + totalScore + "\nYour Time: " + (int)totalTime + " secs\nFinalScore: " + 0;
        }
        
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Tutorial()
    {
        GameObject.Find("TutorialPanel").GetComponent<Image>().enabled = !GameObject.Find("TutorialPanel").GetComponent<Image>().enabled;
        GameObject.Find("TutorialText").GetComponent<Text>().enabled = !GameObject.Find("TutorialText").GetComponent<Text>().enabled;
    }
}
