using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    GameObject player;
    GameObject menuPanel;
    GameObject menuButton;

    Camera[] cams;
    Camera[] cameras;
    SplineWalker[] playerScript;

    public bool toggleMenu;
    public bool reload = false;

    private void Awake()
    {
        cameras = Resources.FindObjectsOfTypeAll<Camera>();
        cams = Resources.FindObjectsOfTypeAll<Camera>();
        playerScript = Resources.FindObjectsOfTypeAll<SplineWalker>();

    }

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        menuPanel = GameObject.Find("MenuPanel");
        menuButton = GameObject.Find("MenuButton");
        menuPanel.SetActive(false);
        toggleMenu = false;
        player = playerScript[0].gameObject;


    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < cams.Length; i++)
        {
            if (cams[i].name == "GlobalCamera" && toggleMenu && cams[i].gameObject.activeSelf)
            {
                GameObject[] buttons = GameObject.FindGameObjectsWithTag("button");
                for (int j = 0; j < buttons.Length; j++)
                {
                    buttons[j].GetComponent<Button>().interactable = false;
                }
            }
            if (cams[i].name == "Main Camera" && toggleMenu && cams[i].gameObject.activeSelf)
            {
                GameObject[] buttons = GameObject.FindGameObjectsWithTag("button");
                for (int j = 0; j < buttons.Length; j++)
                {
                    if(buttons[j].name != "BezierBallButton")
                    {
                        buttons[j].GetComponent<Button>().interactable = true;
                    }
                    else
                    {
                        if(toggleMenu)
                        {
                            buttons[j].GetComponent<Button>().interactable = true;
                        }
                    }
                    
                }
            }            
        }
	}

    public void MenuHandler()
    {
        Camera[] cameras = Camera.FindObjectsOfType<Camera>();
        if (toggleMenu)
        {
            menuPanel.SetActive(false);
            menuButton.GetComponentInChildren<Text>().text = "Menu";

            // freezing camera
            for (int i = 0; i < cameras.Length; i++)
            {
                
                if(!cameras[i].gameObject.activeSelf && cameras[i].name == "Main Camera")
                {
                    cameras[i].gameObject.SetActive(true);
                    cameras[i].gameObject.GetComponent<CameraBehaviour>().enabled = true;
                    cameras[i].gameObject.GetComponent<MouseLook>().enabled = true;
                    cameras[i].gameObject.SetActive(false);
                }
                else if (!cameras[i].gameObject.activeSelf)
                {
                    cameras[i].gameObject.SetActive(true);
                    cameras[i].gameObject.GetComponent<CameraBehaviour>().enabled = true;
                    cameras[i].gameObject.SetActive(false);
                }
                if (cameras[i].name == "Main Camera")
                {
                    cameras[i].gameObject.GetComponent<CameraBehaviour>().enabled = true;
                    cameras[i].gameObject.GetComponent<MouseLook>().enabled = true;
                }
                else
                {
                    cameras[i].gameObject.GetComponent<CameraBehaviour>().enabled = true;
                }
            }
        }
        else
        {
            menuPanel.SetActive(true);
            menuButton.GetComponentInChildren<Text>().text = "Back";
            

            // unfreezing camera
            for (int i = 0; i < cameras.Length; i++)
            {
                if (!cameras[i].gameObject.activeSelf && cameras[i].name == "Main Camera")
                {
                    cameras[i].gameObject.SetActive(false);
                    cameras[i].gameObject.GetComponent<CameraBehaviour>().enabled = false;
                    cameras[i].gameObject.GetComponent<MouseLook>().enabled = false;
                    cameras[i].gameObject.SetActive(false);
                }
                else if (!cameras[i].gameObject.activeSelf)
                {
                    cameras[i].gameObject.SetActive(false);
                    cameras[i].gameObject.GetComponent<CameraBehaviour>().enabled = false;
                    cameras[i].gameObject.SetActive(false);
                }
                if (cameras[i].name == "Main Camera")
                {
                    cameras[i].gameObject.GetComponent<CameraBehaviour>().enabled = false;
                    cameras[i].gameObject.GetComponent<MouseLook>().enabled = false;
                }
                else
                {
                    cameras[i].gameObject.GetComponent<CameraBehaviour>().enabled = false;
                }
            }
        }
        toggleMenu = !toggleMenu;
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene("Scene2");
    }

    public void BezierBallFunction()
    {
        player = GameObject.Find("Player");
        if (!reload)
        {
            GameFlow watcher = GameObject.Find("Watcher").GetComponent<GameFlow>();

            GameObject[] dots = GameObject.FindGameObjectsWithTag("dot");
            for (int i = 0; i < dots.Length; i++)
            {
                dots[i].GetComponent<MeshRenderer>().enabled = false;
                if(i%3 == 1 || i%3 == 2)
                    dots[i].GetComponent<LineRenderer>().enabled = false;
            }

            player.GetComponent<SplineWalker>().enabled = true;
            player.GetComponent<MeshRenderer>().enabled = true;
            player.GetComponent<SphereCollider>().enabled = true;
            player.GetComponent<PlayerCollision>().enabled = true;

            if(SceneManager.GetActiveScene().name == "Scene2")
            {
                GameObject.Find("ScoreText").GetComponent<Text>().enabled = true;
                GameObject.Find("TimeText").GetComponent<Text>().color = new Color(255, 88, 88);
            }

            menuPanel.SetActive(false);
            GameObject.Find("MenuButton").SetActive(false);
            GameObject.Find("Decorator").SetActive(false);
            this.gameObject.GetComponent<Menu>().enabled = false;
            GameObject[] archs = GameObject.FindGameObjectsWithTag("arch");
            for (int i = 0; i < archs.Length; i++)
            {
                archs[i].GetComponentInChildren<BoxCollider>().enabled = true;
            }
            GameObject.Find("Main Camera").GetComponent<CameraBehaviour>().enabled = true;
            GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
        }
        
        
        if (reload)
        {
            reload = false;
            GameObject.Find("MenuButton").SetActive(true);
            GameObject.Find("Decorator").SetActive(true);
            this.gameObject.GetComponent<Menu>().enabled = true;
            menuPanel.SetActive(true);
        }

    }

    private void OnLevelWasLoaded(int level)
    {
        if(level == 1 || level == 2)
        {
            reload = true;
        }
    }
}
