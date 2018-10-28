using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using UnityEngine.UI;

public class Level2HighscoreListName : MonoBehaviour
{
    string line;

    public int rank;

    void Start()
    {
        if (System.IO.File.Exists("Highscore2.txt"))
        {

            using (StreamReader theReader = new StreamReader("Highscore2.txt", Encoding.Default))
            {

                line = theReader.ReadLine();

                string[] entries = line.Split(';');

                Text text = GetComponent<Text>();
                text.text = rank + ".  " + entries[rank * 4 - 4];

            }
        }

        else
        {
            Text text = GetComponent<Text>();
            text.text = rank + ".  -------";
        }
    }
}
