using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraChanger : MonoBehaviour {

    Camera[] cameras;
    Vector3 globalCameraInitialPosition;
    Quaternion globalCameraInitialRotation;
    GameObject globalCamera;
    GameObject watcher;



	// Use this for initialization
	void Start () {
        cameras = Camera.FindObjectsOfType<Camera>();
        ResetCamera();
        globalCamera = GameObject.Find("GlobalCamera");
        globalCamera.GetComponent<CameraBehaviour>().enabled = true;
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetCamera()
    {
        watcher = GameObject.Find("Watcher");
        
        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i].name != "GlobalCamera")
            {
                cameras[i].gameObject.SetActive(false);
            }
            else
            {
                cameras[i].gameObject.SetActive(true);
                cameras[i].gameObject.GetComponent<CameraBehaviour>().enabled = false;
            }
        }
    }

    public void FreeCamera()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i].name != "Main Camera")
            {
                cameras[i].gameObject.SetActive(false);
            }
            else
            {
                cameras[i].gameObject.SetActive(true);
                cameras[i].gameObject.GetComponent<CameraBehaviour>().enabled = false;
                cameras[i].gameObject.GetComponent<MouseLook>().enabled = false;
            }
        }
    }
}
