using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private PlayerController player;
    private GameObject character;
    private Vector3 offset;


	// Use this for initialization
	void Start () 
    {
        character = GameObject.FindWithTag("Player");
        player = character.GetComponent("PlayerController") as PlayerController;
        
        offset = transform.position - character.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () 
    {
        if (player.isDead == false)
            transform.position = character.transform.position + offset;
	}
}
