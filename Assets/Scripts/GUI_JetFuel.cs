using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUI_JetFuel : MonoBehaviour {

    private GameObject play;
    Text text;
    
    // Use this for initialization
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        play = GameObject.FindWithTag("Player");
        PlayerController player = play.GetComponent<PlayerController>();

        if (player.jetFuel > 0)
        {
            text = GetComponent<Text>();
            text.text = "" + player.jetFuel;
        }
    }
}
