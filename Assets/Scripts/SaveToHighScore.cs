using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class SaveToHighScore : MonoBehaviour {

    [DllImport("Leaderboard_DLL", CharSet = CharSet.Ansi, EntryPoint = "addPlayer1")]
    public static extern int addPlayer1(string name, int score, float time, int collectables);
    [DllImport("Leaderboard_DLL", CharSet = CharSet.Ansi, EntryPoint = "addPlayer2")]
    public static extern int addPlayer2(string name, int score, float time, int collectables);
    [DllImport("Leaderboard_DLL", CharSet = CharSet.Auto, EntryPoint = "returnLeaderboard1")]
    public static extern System.IntPtr returnLeaderboard1();
    [DllImport("Leaderboard_DLL", CharSet = CharSet.Auto, EntryPoint = "returnLeaderboard2")]
    public static extern System.IntPtr returnLeaderboard2();

    string Name;
    InputField nameInput;

    int Score;
    int Collectables;
    float Oxygen;

	// Use this for initialization
	void Start () 
    {
        Score = PlayerPrefs.GetInt("Score");
        Collectables = PlayerPrefs.GetInt("Collectables");
        Oxygen = PlayerPrefs.GetFloat("Oxygen");
	}

    public void SaveScore()
    {

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            int i = 0;

            nameInput = FindObjectOfType<InputField>();

            Debug.Log(nameInput);

            Name = nameInput.text;

            Debug.Log(Name);

            i = addPlayer1(Name, Score, Oxygen, Collectables);
            Debug.Log(i);
            Debug.Log(Name);
        }

        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            int i = 0;

            nameInput = FindObjectOfType<InputField>();

            Debug.Log(nameInput);

            Name = nameInput.text;

            Debug.Log(Name);

            i = addPlayer2(Name, Score, Oxygen, Collectables);
            Debug.Log(i);
            Debug.Log(Name);
        }
    }
}
