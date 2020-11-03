using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
using System;

public class csvFilePrinter1 : MonoBehaviour
{
    public Boss boss;
    public Warrior warrior;
    public Rogue rogue;
    public Mage mage;
    public MoonkinDruid druid;
    public Priest priest;
    public Button mainMenuButton;
    public Text BossDamage;
    public Text PlayersDamage;

    private string[] health = new string[6];

    private StreamWriter writer;
    private string filePath;
    private int timeStep;
    private int totalPlayerDmg;
    private int totalBossDamage;

    void Start()
    {
        // get file path
        filePath = getPath();

        // initialize writer with filePath
        writer = System.IO.File.CreateText(filePath);

        // initialize timestep counter to 0
        timeStep = 0;
        mainMenuButton.interactable = false;
    }

    void FixedUpdate()
    {
        // load health values to health array
        loadString();
         
        // if boss dies
        if (boss.isDead == true)
        {
                savePlayerPrefs();
                writer.Flush();
                writer.Close();
                mainMenuButton.interactable = true;
           
        } // if team gets whipped
        else if (warrior.isDead == true || rogue.isDead == true || mage.isDead == true || druid.isDead == true || priest.isDead == true)
        {
                savePlayerPrefs();
                writer.Flush();
                writer.Close();
                mainMenuButton.interactable = true;
        }
        else{
            //write time step increment
            writer.Write(timeStep+",");
            timeStep++;

            totalPlayerDmg += warrior.damage + druid.damage + mage.damage + rogue.damage;
            totalBossDamage += boss.getTotalDmg();
            
            // write health to file
            for(int i = 0; i < health.Length; i++)
            {
                writer.Write(health[i]+",");
            }
            writer.Write("\n");
            if(mainMenuButton.interactable == false;){
                 BossDamage.text = "" + totalBossDamage;
                 PlayersDamage.text = "" + totalPlayerDmg;
            }
        }        
    }

    private string getPath()
    {
        return Application.dataPath + "_Level1.csv";
    }

    private void loadString()
    {
        health[0] = boss.toString();
        health[1] = warrior.toString();
        health[2] = rogue.toString();
        health[3] = mage.toString();
        health[4] = druid.toString();
        health[5] = priest.toString();
    }
      private void savePlayerPrefs(){
        PlayerPrefs.SetInt("BossDmg1", boss.totalDmg);
        int teamDmg = warrior.totalDmg + rogue.totalDmg + mage.totalDmg + druid.totalDmg;
        PlayerPrefs.SetInt("teamDmg1", teamDmg);
        PlayerPrefs.Save();
    }
}
