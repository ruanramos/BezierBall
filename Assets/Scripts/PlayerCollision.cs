using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerCollision : MonoBehaviour {

    GameFlow gameflow;

    private void Start()
    {
        gameflow = GameObject.Find("Watcher").GetComponent<GameFlow>();
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Trigger")
        {
            Destroy(other.gameObject.GetComponentInParent<MeshCollider>());
            GameObject arch = other.transform.parent.gameObject;
            arch.AddComponent<Rigidbody>();
            arch.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
            UpdateScore();
            Destroy(other.gameObject);
            Destroy(arch, 4f);
        }
    }

    public void UpdateScore()
    {
        gameflow.totalScore += gameflow.scorePerArch;
    }
}
