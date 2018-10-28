using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public Transform waypoint;
    private GameObject Character;
    private Rigidbody2D Playerbody;
    private PlayerController Player;
    private Oxygen PlayerOxygen;
    public float speed = 20f;

	// Use this for initialization
	void Start () {
        Character = GameObject.FindWithTag("Player");
        Playerbody = Character.GetComponent("Rigidbody2D") as Rigidbody2D;
        Player = Character.GetComponent("PlayerController") as PlayerController;
        PlayerOxygen = FindObjectOfType<Oxygen>();

        //death = FindObjectOfType<Death>();
	}
	
	// Update is called once pe-r frame
	void FixedUpdate () {
        Vector2 temp = new Vector2(waypoint.position.x - GetComponent<Rigidbody2D>().position.x, waypoint.position.y - GetComponent<Rigidbody2D>().position.y);
        GetComponent<Rigidbody2D>().velocity = temp.normalized * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !Player.isDead && other is BoxCollider2D)
        {
            PlayerOxygen.oxygen -= 10;

            Player.knockedBackDuration = 0.5f;

            Playerbody.velocity = new Vector2(-Playerbody.velocity.x, -0.9f * Playerbody.velocity.y);

            if (Playerbody.velocity.x < 10 && Playerbody.velocity.x > -10)
            {
                Vector2 distance = new Vector2(Playerbody.position.x - GetComponent<Rigidbody2D>().position.x, Playerbody.position.y - GetComponent<Rigidbody2D>().position.y);

                if (distance.x > 0)
                    Playerbody.velocity = new Vector2(10, Playerbody.velocity.y);
                
                else
                    Playerbody.velocity = new Vector2(-10, Playerbody.velocity.y);
            }
        }
    }
}
