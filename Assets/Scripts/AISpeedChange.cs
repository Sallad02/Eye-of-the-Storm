using UnityEngine;
using System.Collections;

public class AISpeedChange : MonoBehaviour {

    public float newSpeed = 8f;
    public FollowAI AI;
	// Use this for initialization
	void Start () {
        AI = FindObjectOfType<FollowAI>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("Hit something");
        if (other.tag == "FolowAI") 
        {
            AI.speed = newSpeed;
            Debug.Log("Hit FolowAI");
        }
    }
}
