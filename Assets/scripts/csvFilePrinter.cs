using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;

public class csvFilePrinter : MonoBehaviour
{
    public Boss boss;
    public Warrior warrior;
    public Rogue rogue;
    public Mage mage;
    public MoonkinDruid druid;
    public Priest priest;

    private string[] health = new string[5];

    private StreamWriter writer;
    private string filePath;
    private int timeStep;

    void Start()
    {
        // get file path
        filePath = getPath();

        // initialize writer with filePath
        writer = System.IO.File.CreateText(filePath);

        // initialize timestep counter to 0
        timeStep = 0;
    }

    void FixedUpdate()
    {
        // load health values to health array
        loadString();

        //write time step increment
        writer.WriteLine(timeStep);
        timeStep++;

        // write health to file
        for(int i = 0; i < health.Length; i++)
            writer.WriteLine(health[i]);

        // if boss dies
        if (boss.isDead == true)
        {
            writer.Flush();
            writer.Close();
        } // if team gets whipped
        else if (warrior.isDead == true
                && rogue.isDead == true
                && mage.isDead == true
                && druid.isDead == true
                && priest.isDead == true)
        {
            writer.Flush();
            writer.Close();
        }
    }

    private string getPath()
    {
        return Application.dataPath + "health_log.csv";
    }

    private void loadString()
    {
        health[0] = boss.toString();
        health[1] = warrior.toString();
        health[2] = rogue.toString();
        health[3] = mage.toString();
        health[4] = druid.toString();
    }
}
