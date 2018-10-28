using UnityEngine;
using System.Collections;

public class MusicVolume : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Music") * PlayerPrefs.GetFloat("Master");
    }
}
