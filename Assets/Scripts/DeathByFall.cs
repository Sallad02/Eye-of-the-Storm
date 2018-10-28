using UnityEngine;
using System.Collections;

public class DeathByFall : MonoBehaviour {

    private GameObject character;
    private PlayerController player;

	// Use this for initialization
	void Start () 
    {
        character = GameObject.FindWithTag("Player");
        //Debug.Log ("Found: " + play);
        player = character.GetComponent("PlayerController") as PlayerController;
        //Debug.Log ("Found on " + play + ": " + player);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            character.GetComponent<Death>().death();
        }
    }
}
