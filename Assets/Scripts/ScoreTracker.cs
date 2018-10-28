using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class ScoreTracker : MonoBehaviour {

    [DllImport("Leaderboard_DLL", CharSet = CharSet.Ansi, EntryPoint = "addPlayer")]
    public static extern int addPlayer(string name, int score, float time, int collectables);
    [DllImport("Leaderboard_DLL", CharSet = CharSet.Auto, EntryPoint = "returnLeaderboard")]
    public static extern System.IntPtr returnLeaderboard();

    public int Score;
    //public double Timer;
    public int Collectables;

    public Oxygen Ox;

    public PlayerController PC;

    //bool scoreAdded = false;

    //public int onWin()
    //{
    //    compileScore();
    //    Debug.Log(Score);
    //    addToLeaderboard("Player1");

    //    return Score;
    //}

    string getLeaderboard() 
    {
        return Marshal.PtrToStringAnsi(returnLeaderboard());
    }

    public int compileScore() 
    {
        Ox = FindObjectOfType<Oxygen>();
        Score = Mathf.RoundToInt(Ox.oxygen * 100 + Collectables * 2000);

        Debug.Log(Score);

        return Score;
    }

    //public int getScore()
    //{
    //    Debug.Log(Score);

    //    return Score;
    //}


    //void addToLeaderboard(string name) 
    //{
    //    int i = 0;
    //    i = addPlayer(name, Score, Ox.oxygen, Collectables);
    //    Debug.Log(i);
    //}

}
