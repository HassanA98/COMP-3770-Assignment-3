using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.UI;
using System;
public class ScoreUpdater : MonoBehaviour
{
    public Text L1Player;
    public Text L2Player;
    public Text L3Player;
    public Text L1Boss;
    public Text L2Boss;
    public Text L3Boss; 
    private StreamWriter writer;
    private string filepath1;
    private string filepath2;
    private string filepath3;
    // Start is called before the first frame update
    void Start()
    {
        filepath1 = Application.dataPath + "_Level1.csv";
        filepath2 = Application.dataPath + "_Level2.csv";
        filepath3 = Application.dataPath + "_Level3.csv";

        if (File.Exists(filepath1))
        {
            string lastLine = File.ReadLines(filepath1).Last();
            string[] scores = lastLine.Split(',');

            L1Boss.text = scores[0].ToString();
            L1Player.text = scores[1].ToString();

        }

        if (File.Exists(filepath2))
        {
            string lastLine = File.ReadLines(filepath2).Last();
            string[] scores = lastLine.Split(',');

            L2Boss.text = scores[0].ToString();
            L2Player.text = scores[1].ToString();
        }

        if (File.Exists(filepath3))
        {
            string lastLine = File.ReadLines(filepath3).Last();
            string[] scores = lastLine.Split(',');

            L3Boss.text = scores[0].ToString();
            L3Player.text = scores[1].ToString();
        }
    }
}
