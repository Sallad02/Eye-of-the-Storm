using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

	public GameObject Character;

	// Use this for initialization
	void Start () {
		spawn ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void spawn(){
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		Character.transform.position = transform.position;
		Instantiate (Character);
	}
}
