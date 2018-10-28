using UnityEngine;
using System.Collections;

public class FollowThis : MonoBehaviour {
    public GameObject waypoint;
    public Transform folowing;
    public GameObject folower;
    private WaypointNext script;
    private FollowAI scriptAI;
    private GameObject waypoint1;
    private GameObject waypoint2;
    public float delay = 1f;
    float i = 0;
	// Use this for initialization
	void Start () {
        folower = GameObject.FindWithTag("FolowAI");
        folowing = GameObject.FindWithTag("Player").transform;
        waypoint1 = Instantiate(waypoint);
        scriptAI = folower.GetComponent(typeof(FollowAI)) as FollowAI;
        scriptAI.waypoint = waypoint1.transform;
        scriptAI.player = folowing.transform;
        script = waypoint1.GetComponent(typeof(WaypointNext)) as WaypointNext;
        script.enemy = folower.GetComponent(typeof(FollowAI)) as FollowAI;
        
	}
	
	// Update is called once per frame
	void Update () {
        
        i -= Time.deltaTime;
        if (i <= 0)
        {
            waypoint2 = Instantiate(waypoint);
            script.next = waypoint2.transform;
            script = waypoint2.GetComponent(typeof(WaypointNext)) as WaypointNext;
            script.enemy = folower.GetComponent(typeof(FollowAI)) as FollowAI;
            waypoint1 = waypoint2;
            i = delay;
        }
        else {
            waypoint1.transform.position = folowing.position;
        }

	}

    
}
