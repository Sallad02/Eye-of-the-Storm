using UnityEngine;
using System.Collections;

public class Soundcontroller : MonoBehaviour {

	// Use this for initialization
	public AudioClip[] totwalk;
	public AudioClip Jump;
	public AudioClip landing;
	public AudioClip hit;
	public AudioClip Shocktrap;
	public AudioClip Antigrav;
	public AudioClip jetfuel;
	public AudioClip speedboost;
	public AudioClip jetpack;
	public float fxVol;
	float volume;
	float pitch;
	AudioSource audio;
	PlayerController play;
	void Awake () {
		audio = GetComponent<AudioSource> ();
		play = GetComponent<PlayerController> ();
		InvokeRepeating ("playsound", 0, 0.3f);
	}

	// Update is called once per frame
	void Update () {
		fxVol = PlayerPrefs.GetFloat("SFX");
		if (play.grounded) {
			if (Input.GetKeyDown ("space")) { //grund till hopp ljud //Simon
				pitch = Random.Range (0.75f, 1.25f);
				audio.pitch = pitch;
				volume = Random.Range (0.1f, 0.3f);
				volume = volume * fxVol * PlayerPrefs.GetFloat("Master");
				audio.PlayOneShot (Jump, volume);
			}
		}


	}

	void playsound(){
		if(play.grounded){
			if (Input.GetButton("Horizontal")) {
				volume = Random.Range (0.25f, 0.5f);
				volume = volume * fxVol * PlayerPrefs.GetFloat("Master");
				pitch = Random.Range (0.75f, 1.25f);
				audio.pitch = pitch;
				int selection = Random.Range (0, totwalk.Length);
				audio.PlayOneShot (totwalk [selection], volume);
			}
		}
		if (play.jetFuel > 0 && Input.GetKey ("space")) {
			volume = Random.Range (0.05f, 0.1f);
			volume = volume * fxVol * PlayerPrefs.GetFloat("Master");
			audio.PlayOneShot (jetpack, volume);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(play.grounded){
				pitch = Random.Range (0.75f, 1.25f);
				audio.pitch = pitch;
				volume = Random.Range (0.1f, 0.3f);
				volume = volume * fxVol * PlayerPrefs.GetFloat("Master");
				audio.PlayOneShot (landing, volume);
		}	
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Enemy") {
			pitch = Random.Range (0.75f, 1.25f);
			audio.pitch = pitch;
			volume = Random.Range (0.1f, 0.3f);
			volume = volume * fxVol * PlayerPrefs.GetFloat("Master");
			audio.PlayOneShot (hit, volume);
		}
		if (coll.gameObject.tag == "Shocktrap") {
			pitch = Random.Range (0.75f, 1.25f);
			audio.pitch = pitch;
			volume = Random.Range (0.1f, 0.3f);
			volume = volume * fxVol * PlayerPrefs.GetFloat("Master");
			audio.PlayOneShot (Shocktrap, volume);
		}
		if (coll.gameObject.tag == "antigrav") {
			pitch = Random.Range (0.75f, 1.25f);
			audio.pitch = pitch;
			volume = Random.Range (0.1f, 0.3f);
			volume = volume * fxVol * PlayerPrefs.GetFloat("Master");
			audio.PlayOneShot (Antigrav, volume);
		}
		if (coll.gameObject.tag == "jetfuel") {
			pitch = Random.Range (0.75f, 1.25f);
			audio.pitch = pitch;
			volume = Random.Range (0.1f, 0.3f);
			volume = volume * fxVol * PlayerPrefs.GetFloat("Master");
			audio.PlayOneShot (jetfuel, volume);
		}
		if (coll.gameObject.tag == "speedboost") {
			pitch = Random.Range (0.75f, 1.25f);
			audio.pitch = pitch;
			volume = Random.Range (0.1f, 0.3f);
			volume = volume * fxVol * PlayerPrefs.GetFloat("Master");
			audio.PlayOneShot (speedboost, volume);
		}
	}
}
