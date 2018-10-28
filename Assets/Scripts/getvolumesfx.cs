using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class getvolumesfx : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponentInChildren<Slider> ().value = PlayerPrefs.GetFloat ("SFX");
	}
	
	// Update is called once per frame
	void Update () {
		PlayerPrefs.SetFloat("SFX", GetComponent<Slider>().value);
	}
}
