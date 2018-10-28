using UnityEngine;
using System.Collections;

public class jetFuel : MonoBehaviour {

    public float fuelAmount;

    private PlayerController player;
    private GameObject character;

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
            if (player.isPoweredUp)
                player.powerDown();

            player.isPoweredUp = true;
            player.jetFuel = fuelAmount;

            gameObject.SetActive(false);
        }
    }
}
