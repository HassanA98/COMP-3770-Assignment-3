using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;
using UnityEngine.UI;

public class csvFilePrinter : MonoBehaviour
{
    public Boss boss;
    public Warrior warrior;
    public Rogue rogue;
    public Mage mage;
    public MoonkinDruid druid;
    public Priest priest;
    public Button button;

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
        
        // disable button
        button.interactable = false;
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
            savePlayerPrefs();
            writer.Flush();
            writer.Close();
            button.interactable = true;
        } // if any team meber is killed
        else if (warrior.isDead == true
                || rogue.isDead == true
                || mage.isDead == true
                || druid.isDead == true
                || priest.isDead == true)
        {
            killTeam();
            savePlayerPrefs();
            writer.Flush();
            writer.Close();
            button.interactable = true;
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
    
    private void savePlayerPrefs(){
        PlayerPrefs.SetInt("BossDmg1", boss.totalDmg);
        int teamDmg = warrior.totalDmg + rogue.totalDmg + mage.totalDmg + druid.totalDmg;
        PlayerPrefs.SetInt("teamDmg1", teamDmg);
        PlayerPrefs.Save();
    }
    private void killTeam()
    {
        warrior.isDead = true;
        rogue.isDead = true;
        mage.isDead = true;
        druid.isDead = true;
    }
}
