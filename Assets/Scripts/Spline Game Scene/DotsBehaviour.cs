using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotsBehaviour : MonoBehaviour {

    Vector3 cameraToPoint;
    float distance;
    LineRenderer controlPointToSplinePointLine;

    Color color;

    private void Start()
    {
        controlPointToSplinePointLine = gameObject.GetComponent<LineRenderer>();
        color = gameObject.GetComponent<Renderer>().material.color;
    }

    private void OnMouseDrag()
    {   
        transform.position =  Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));
    }

    private void OnMouseDown()
    {
        cameraToPoint = new Vector3(Camera.main.transform.position.x - transform.position.x, 
            Camera.main.transform.position.y - transform.position.y, Camera.main.transform.position.z - transform.position.z);
        distance = cameraToPoint.magnitude;
    }

    private void OnMouseEnter()
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white);

    }


    private void OnMouseExit()
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", color);
    }

}
