using UnityEngine;
using System.Collections;

public class EnemySpawnPoint : MonoBehaviour
{

    public GameObject Enemy;
    public GameObject Waypoint;

    private EnemyAI EAI;
    private WaypointNext WP1;
    private WaypointNext WP2;

    public Transform waypoint1;
    public Transform waypoint2;

    // Use this for initialization
    void Start()
    {
        spawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnEnemy()
    {
        //gameObject.GetComponent<SpriteRenderer>().enabled = false;

        Enemy.transform.position = transform.position;
        Instantiate(Enemy);

        EAI = GameObject.FindObjectOfType<EnemyAI>();

        Waypoint.transform.position = waypoint1.position;
        Instantiate(Waypoint);

        WP1 = GameObject.FindObjectOfType<WaypointNext>();

        Waypoint.transform.position = waypoint2.position;
        Instantiate(Waypoint);

        WP2 = GameObject.FindObjectOfType<WaypointNext>();

        EAI.waypoint = WP1.transform;

        WP1.enemyAI = EAI;
        WP1.next = WP2.transform;
        WP2.enemyAI = EAI;
        WP2.next = WP1.transform;

        
    }
}
