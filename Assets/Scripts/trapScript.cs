using UnityEngine;
using System.Collections;

public class trapScript : MonoBehaviour {

    private PlayerController player;
    public float duration = 2f;

    // Use this for initialization
    void Start () {
        GameObject play = GameObject.FindWithTag("Player");
        Debug.Log("Found: " + play);
        player = play.GetComponent("PlayerController") as PlayerController;
        Debug.Log("Found on " + play + ": " + player);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.isStunned = true;
            player.stunnedDuration = duration;
            
            player.maxSpeed = 0;
            player.jumpForce = 0;
            player.powerDown();
            
            gameObject.SetActive(false);
        }

        
    }
}
