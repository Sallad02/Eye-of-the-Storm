using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gui_oxygen : MonoBehaviour {

	private GameObject play;
	Text text;
	// Use this for initialization
	void Awake () {
		//play = GameObject.FindWithTag ("Player");
		//Oxygen oxy = play.GetComponent<Oxygen>();
		//text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () 
    {
		play = GameObject.FindWithTag ("Player");
		Oxygen oxy = play.GetComponent<Oxygen>();

		text = GetComponent<Text>();
		text.text = "" + oxy.oxygen;
	}
}
