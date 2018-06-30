using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraBehaviour : MonoBehaviour {

    float flySpeed = 0.6f;
    GameObject defaultCam;
    GameObject playerObject;
    bool isEnabled;
 
    bool shift;
    bool ctrl;
    float accelerationAmount = 1.5f;
    float accelerationRatio = 0.3f;
    float slowDownRatio = 0.2f;


    Camera[] cams;
    


    private void FixedUpdate()
    {
        if (this.gameObject.name == "BallCamera")
        {
            GameObject player = GameObject.Find("Player");
            transform.position = player.transform.position;
            transform.rotation = player.transform.rotation;
        }
    }

    // Update is called once per frame
    void Update () {

        if(this.gameObject.name == "Main Camera")
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                transform.Translate(Vector3.forward * flySpeed * 100 * Input.GetAxis("Mouse ScrollWheel"));
            }


            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                transform.Translate(Vector3.forward * flySpeed * 100 * (Input.GetAxis("Mouse ScrollWheel")));
            }

            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.up * flySpeed);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.down * flySpeed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * flySpeed);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * flySpeed);
            }

            if (Input.GetMouseButtonDown(1))
            {
                this.gameObject.GetComponent<MouseLook>().enabled = !this.gameObject.GetComponent<MouseLook>().enabled;
            }
        }

        if(this.gameObject.name == "GlobalCamera")
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f && transform.position.x <= -50f && transform.position.y >= 27.60674f)
            {
                transform.Translate(Vector3.forward * flySpeed * 400 * Input.GetAxis("Mouse ScrollWheel"));
            }


            if (Input.GetAxis("Mouse ScrollWheel") < 0f && transform.position.x >= -110f && transform.position.y <= 44f)
            {
                transform.Translate(Vector3.forward * flySpeed * 400 * (Input.GetAxis("Mouse ScrollWheel")));
            }

            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.up * flySpeed * 3);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.down * flySpeed * 3);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * flySpeed * 3);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * flySpeed * 3);
            }
        }        
    }
}
