using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour {

    private PlayerController player;
    private Oxygen oxygen;
    private GameObject character;

    //private Animator anim;

	// Use this for initialization
	void Start () 
    {
        //anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void death()
    {
        character = GameObject.FindWithTag("Player");
        player = character.GetComponent("PlayerController") as PlayerController;

        oxygen = character.GetComponent("Oxygen") as Oxygen;

        oxygen.enabled = false;

        player.powerDown();

        player.isDead = true;

        //anim.SetBool("Is Dead", true);
	}
}
