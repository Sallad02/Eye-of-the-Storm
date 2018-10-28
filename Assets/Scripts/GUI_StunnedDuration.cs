using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUI_StunnedDuration : MonoBehaviour {

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
        text = GetComponent<Text>();
        text.text = "" + player.stunnedDuration;
    }
}
