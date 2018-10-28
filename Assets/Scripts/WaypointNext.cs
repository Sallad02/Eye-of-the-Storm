 using UnityEngine;
using System.Collections;

public class WaypointNext : MonoBehaviour {

    public Transform next;
    public FollowAI enemy;
    public EnemyAI enemyAI;
    public float speed;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FolowAI")
        {
                enemy.waypoint = next;
                Destroy(gameObject);
                //gameObject.SetActive(false);
        }
        else if (other.tag == "Enemy") {
            enemyAI.waypoint = next;
            enemyAI.speed = speed;
        }

    }
}
