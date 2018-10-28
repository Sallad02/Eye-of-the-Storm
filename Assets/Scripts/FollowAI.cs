using UnityEngine;
using System.Collections;

public class FollowAI : MonoBehaviour {

    public Transform waypoint;
    public Transform player;
    public bool isFollowing = false;
    float velocety = 0;

    private Oxygen Player;

    public float speed = 20f;
    public bool followX = false;
    // Use this for initialization
	void Start () {
        Player = FindObjectOfType<Oxygen>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {


        Vector2 distance = new Vector2(player.position.x - GetComponent<Rigidbody2D>().position.x, player.position.y - GetComponent<Rigidbody2D>().position.y);
        if (distance.magnitude > 40 && isFollowing)
        {
            velocety = 35;
        }
        else
        {
            velocety = speed;
        }

        Vector2 temp;
        if (waypoint == null)
        {
            temp = new Vector2(player.position.x - GetComponent<Rigidbody2D>().position.x, player.position.y - GetComponent<Rigidbody2D>().position.y);
        }
        else {
            temp = new Vector2(waypoint.position.x - GetComponent<Rigidbody2D>().position.x, waypoint.position.y - GetComponent<Rigidbody2D>().position.y);
        }
        GetComponent<Rigidbody2D>().velocity = temp.normalized * velocety;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") 
        {
            Player.oxygen = 0;
            speed = 0;
        }
    }
}
