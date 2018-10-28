using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Finish : MonoBehaviour {

    private ScoreTracker SC;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player" && other is BoxCollider2D) {
			Debug.Log ("Winner, script winning state in OnWin() inside Finish script!");
			OnWin ();
		}
	}

	void OnWin(){

        SC = FindObjectOfType<ScoreTracker>();

        int Score = SC.compileScore();
        int Collectables = SC.Collectables;
        float Oxygen = SC.Ox.oxygen;

        PlayerPrefs.SetInt("Score", Score);
        PlayerPrefs.SetInt("Collectables", Collectables);
        PlayerPrefs.SetFloat("Oxygen", Oxygen);


        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(3);
        }

        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(4);
        }
	}
}
