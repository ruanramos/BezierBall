using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArchSpawnner : MonoBehaviour {

    public GameObject archPrefab;
    GameObject cage;

    public int numberOfArchs = 5;
    int diameterOfCage = 100;
    

    Vector3[] spawnPoints;
    Vector3[] archRotation;
    Vector3[] archScale;


    // Use this for initialization
    void Start () {
        if (SceneManager.GetActiveScene().name != "FreePlay")
        {
            cage = GameObject.Find("Cage");
            cage.transform.localScale = new Vector3(diameterOfCage, diameterOfCage, diameterOfCage);
        }
        int limitForArch = diameterOfCage / 2;
        int offsetFromCage = diameterOfCage * 20 / 100;
        spawnPoints = new Vector3[numberOfArchs];
        archRotation = new Vector3[numberOfArchs];
        archScale = new Vector3[numberOfArchs];
        for (int i = 0; i < numberOfArchs; i++)
        {
            float scaleXY = Random.Range(0.5f, 1.5f);
            archScale[i] = new Vector3(scaleXY, scaleXY, Random.Range(1f, 5f));
            spawnPoints[i] = new Vector3(Random.Range(-1 * limitForArch + offsetFromCage, limitForArch - offsetFromCage),
                Random.Range(-1 * limitForArch + offsetFromCage, limitForArch - offsetFromCage), Random.Range(-1 * limitForArch + offsetFromCage, limitForArch - offsetFromCage));
            archRotation[i] = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));

            // need to check if archs are one inside the other before instaciating

            GameObject arch = Instantiate(archPrefab, spawnPoints[i], Quaternion.Euler(archRotation[i]));
            arch.name = "Arch " + i;
            //arch.transform.localScale = archScale[i];
        }
	}
	
	// Update is called once per frame
	void Update () {
	}
}
