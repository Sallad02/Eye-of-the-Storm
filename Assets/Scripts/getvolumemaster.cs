using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class getvolumemaster : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponentInChildren<Slider> ().value = PlayerPrefs.GetFloat ("Master");
	}
	
	// Update is called once per frame
	void Update () {
		PlayerPrefs.SetFloat("Master", GetComponent<Slider>().value);
	}
}
