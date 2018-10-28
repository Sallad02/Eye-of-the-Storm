using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUI_Pickups : MonoBehaviour {

    private ScoreTracker Pickups;
    Text text;

    // Use this for initialization
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Pickups = FindObjectOfType<ScoreTracker>();
        text = GetComponent<Text>();
        text.text = "" + Pickups.Collectables;
    }
}
