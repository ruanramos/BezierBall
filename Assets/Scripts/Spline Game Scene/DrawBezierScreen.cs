using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrawBezierScreen : MonoBehaviour {

    public GameObject prefabCurvePoint;
    public GameObject prefabControlPoint;
    public GameObject prefabFirstPoint;
    public Vector3[] points;
    public bool addedCurve;

    GameObject decorator;
    public BezierSpline spline;

    public bool moved;

    public float totalDistanceOfTheSpline;
    
	
	// Update is called once per frame
	void Update () {
        for (int count = 0; count < points.Length; count++)
        {
            Vector3 newPos = GameObject.Find("point " + count).transform.position;
            if(GameObject.Find("spline").GetComponent<BezierSpline>().points[count] != newPos || spline.removedCurve)
            {
                moved = true;
                decorator.SetActive(false);
                spline.removedCurve = false;
            }
            GameObject.Find("spline").GetComponent<BezierSpline>().points[count] = newPos;
        }

        if(moved)
        {
            points = GameObject.Find("spline").GetComponent<BezierSpline>().points;
            int counter = 0;
            foreach (Vector3 point in points)
            {
                // instantiate point
                GameObject dot;
                if (counter % 3 != 0)
                {
                    dot = GameObject.Find("point " + counter);
                    // Draw control point line
                    if (counter % 3 == 1)
                    {
                        dot.GetComponent<LineRenderer>().SetPositions(new Vector3[]{new Vector3(points[counter + 1].x, points[counter + 1].y, points[counter + 1].z), dot.transform.position,
                    new Vector3(points[counter - 1].x, points[counter - 1].y, points[counter - 1].z)});
                    }
                    else if (counter % 3 == 2)
                    {
                        dot.GetComponent<LineRenderer>().SetPositions(new Vector3[]{new Vector3(points[counter - 1].x, points[counter - 1].y, points[counter - 1].z), dot.transform.position,
                    new Vector3(points[counter + 1].x, points[counter + 1].y, points[counter + 1].z)});
                    }
                }
                counter++;
            }
        }

        moved = false;

        decorator.SetActive(true);
        addedCurve = false;

        // calculating how big is the spline for punctuation
        for (int count = 0; count < points.Length; count++)
        {

        }
    }

    private void OnEnable()
    {
        updateSpline();
    }

    private void Start()
    {
        spline = GameObject.Find("spline").GetComponent<BezierSpline>();
    }

    void updateSpline()
    {
        // Destroy points
        GameObject[] dots = GameObject.FindGameObjectsWithTag("dot");
        for (int i = 0; i < dots.Length; i++)
        {
            Destroy(dots[i]);
        }
        moved = false;
        addedCurve = false;
        decorator = GameObject.Find("Decorator");
        points = GameObject.Find("spline").GetComponent<BezierSpline>().points;
        int counter = 0;
        foreach (Vector3 point in points)
        {
            // instantiate point
            GameObject dot;
            if (counter == 0)
            {
                dot = Instantiate(prefabFirstPoint, new Vector3(point.x, point.y, point.z), transform.rotation);
                dot.name = "point " + counter;
            } else if(counter % 3 != 0)
            {
                dot = Instantiate(prefabControlPoint, new Vector3(point.x, point.y, point.z), transform.rotation);
            }else
            {
                dot = Instantiate(prefabCurvePoint, new Vector3(point.x, point.y, point.z), transform.rotation);
            }
            dot.name = "point " + counter;

            // Draw line
            if (counter % 3 != 0 && counter != 0)
            {
                // Draw control point line
                if (counter % 3 == 1)
                {
                    dot.GetComponent<LineRenderer>().SetPositions(new Vector3[]{new Vector3(points[counter + 1].x, points[counter + 1].y, points[counter + 1].z), dot.transform.position,
                    new Vector3(points[counter - 1].x, points[counter - 1].y, points[counter - 1].z)});
                }
                // Draw curve point line
                else if (counter % 3 == 2)
                {
                    dot.GetComponent<LineRenderer>().SetPositions(new Vector3[]{new Vector3(points[counter - 1].x, points[counter - 1].y, points[counter - 1].z), dot.transform.position,
                    new Vector3(points[counter + 1].x, points[counter + 1].y, points[counter + 1].z)});
                }
            }            
            counter++;

        }
    }

    IEnumerator WaitSeconds(float sec)
    {
        yield return new WaitForSeconds(sec);
    }
}
