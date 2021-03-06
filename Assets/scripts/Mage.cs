﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mage : MonoBehaviour
{
    public int health;
    public int maxHealth = 1000;
    public int damage;
    public int totalDmg;
    public bool isDead;

    public Boss boss;

    private int random;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        damage = 0;
        totalDmg = 0;
        isDead = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDead == false)
            dealDamage();

        if (health <= 0) 
            isDead = true;
    }

    public void dealDamage()
    {
        random = (int) Random.Range(1, 31);
        damage = random;
        boss.health -= damage;
        totalDmg += damage;
    }

    public string toString()
    {
        return "Mage," + health + ",";
    }
}
