using UnityEngine;
using System.Collections;

public class SpeedBoost : MonoBehaviour{

    private bool isActive;
    public float duration;

    private PlayerController player;

    // Use this for initialization
    void Start()
    {
        GameObject play = GameObject.FindWithTag("Player");
        Debug.Log("Found: " + play);
        player = play.GetComponent("PlayerController") as PlayerController;
        Debug.Log("Found on " + play + ": " + player);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (player.isPoweredUp)
                player.powerDown();

            player.acceleration *= 1000f;
            player.maxSpeed *= 2f;

            player.isPoweredUp = true;
            player.hasSpeedBoost = true;
            player.powerUpDuration = duration;

            gameObject.SetActive(false);
        }
    }
}