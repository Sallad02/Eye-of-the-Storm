using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Oxygen : MonoBehaviour {

	public float oxygen;

    private Animator anim;

	// Use this for initialization
	void Start () 
    {
		//StartCoroutine (decrease());
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        oxygen -= Time.deltaTime;

        if (oxygen <= 0) {
            oxygen = 0;
            anim.SetTrigger("Is Dead");
            gameObject.GetComponent<Death> ().death ();
		}
	}

    //IEnumerator decrease(){
    //    yield return new WaitForSeconds(1.0f);
    //    oxygen -= 1;
    //    StartCoroutine (decrease2());
    //    StopCoroutine (decrease());
    //}

    //IEnumerator decrease2(){
    //    yield return new WaitForSeconds(1.0f);
    //    StartCoroutine (decrease());
    //    StopCoroutine (decrease2());
    //}
}
