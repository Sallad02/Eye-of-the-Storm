using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class getvolumemusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponentInChildren<Slider> ().value = PlayerPrefs.GetFloat ("Music");
	}
	
	// Update is called once per frame
	void Update () {
		PlayerPrefs.SetFloat("Music", GetComponent<Slider>().value);
	}
}
