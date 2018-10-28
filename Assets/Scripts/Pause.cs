using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    private PlayerController player;
    private GameObject character;

    //private GameObject PauseScreen;

	// Use this for initialization
	void Start () {

        character = GameObject.FindWithTag("Player");
        player = character.GetComponent("PlayerController") as PlayerController;

        //PauseScreen = GameObject.Find("Pause Screen");

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1 && !player.isDead)
            {
                Time.timeScale = 0;
                //PauseScreen.SetActive(true);
            }

            else {
                Time.timeScale = 1;
                //PauseScreen.SetActive(false);
            }

        }
	}
}
