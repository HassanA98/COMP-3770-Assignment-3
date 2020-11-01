using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
using System;

public class csvFilePrinter3 : MonoBehaviour
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

    private string[] health = new string[5];

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
            if(mainMenuButton.interactable == false)
            {
                writer.WriteLine(BossDamage.text+","+PlayersDamage.text);

                writer.Flush();
                writer.Close();
                mainMenuButton.interactable = true;
            }
        } // if team gets whipped
        else if (warrior.isDead == true || rogue.isDead == true || mage.isDead == true || druid.isDead == true || priest.isDead == true)
        {
            if(mainMenuButton.interactable == false)
            {
                writer.WriteLine(BossDamage.text+","+PlayersDamage.text);

                writer.Flush();
                writer.Close();
                mainMenuButton.interactable = true;
            }
        }
        else{
            //write time step increment
            writer.Write(timeStep+",");
            timeStep++;

            totalPlayerDmg += warrior.damage + druid.damage + mage.damage + rogue.damage;
            warrior.health -= boss.getTotalDmg()/100;
            totalBossDamage += boss.getTotalDmg() + (boss.getTotalDmg()/100);
            
            // write health to file
            for(int i = 0; i < health.Length; i++)
            {
                writer.Write(health[i]+",");
            }
            writer.Write("\n");
            BossDamage.text = totalBossDamage.ToString();
            PlayersDamage.text = totalPlayerDmg.ToString();
        }        
    }

    private string getPath()
    {
        return Application.dataPath + "_Level3.csv";
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
