using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    public int health;
    public int maxHealth = 3000;
    public int damage;
    public int totalDmg;
    public bool isDead;

    public Boss boss;

    private int random;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        damage = 5;
        totalDmg = 0;
        isDead = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDead == false)
            dealDamage();

        if (health <= 0) {
            isDead = true;
            PlayerPrefs.SetInt("WarriorDmg", totalDmg);
            PlayerPrefs.Save();
        }
    }

    public void dealDamage()
    {
        boss.health -= damage;
        totalDmg += damage;
    }

    public string toString()
    {
        return "Warrior," + health;
    }
}
