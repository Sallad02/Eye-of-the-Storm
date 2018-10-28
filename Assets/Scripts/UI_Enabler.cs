using UnityEngine;
using System.Collections;

public class UI_Enabler : MonoBehaviour {

    private GameObject DeathScreen;
    private GameObject JetFuel;
    private GameObject PowerupDuration;
    private GameObject Stunned;
    private GameObject PauseScreen;
    private GameObject character;
    private PlayerController player;

	// Use this for initialization
	void Start () 
    {
        DeathScreen = GameObject.Find("DeathScreen");
        DeathScreen.SetActive(false);

        JetFuel = GameObject.Find("Jet Fuel");
        JetFuel.SetActive(false);

        PowerupDuration = GameObject.Find("Powerup Duration");
        PowerupDuration.SetActive(false);

        Stunned = GameObject.Find("Stunned Duration");
        Stunned.SetActive(false);

        PauseScreen = GameObject.Find("Pause Screen");
        PauseScreen.SetActive(false);

        character = GameObject.FindWithTag("Player");
        player = character.GetComponent("PlayerController") as PlayerController;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (player.jetFuel > 0)
            JetFuel.SetActive(true);
        else
            JetFuel.SetActive(false);

        
        
        if (player.powerUpDuration > 0)
            PowerupDuration.SetActive(true);
        else
            PowerupDuration.SetActive(false);

        
        
        if (player.isStunned)
            Stunned.SetActive(true);
        else
            Stunned.SetActive(false);

       
        
        if (Time.timeScale == 0)
            PauseScreen.SetActive(true);
        else
            PauseScreen.SetActive(false);

        
        if (player.isDead)
        {
            DeathScreen.SetActive(true);
            PowerupDuration.SetActive(false);
            JetFuel.SetActive(false);
            Stunned.SetActive(false);
        }
	}
}
