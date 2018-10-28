using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour {

    public ScoreTracker SC;
	// Use this for initialization
	void Start () {
        SC = FindObjectOfType<ScoreTracker>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            SC.Collectables += 1;
            Destroy(gameObject);
        }
    }
}
