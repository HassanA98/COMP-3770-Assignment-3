using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    public int health;
    public int maxHealth = 3000;
    public int damage;
    public int tDamage;
    public bool isDead;

    public Boss boss;

    private int random;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        damage = 5;
        tDamage = 0;
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
        boss.health -= damage;
        tDamage += damage;
    }

    public string toString()
    {
        return "Warrior," + health;
    }
}
