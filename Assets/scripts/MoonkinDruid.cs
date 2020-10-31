using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonkinDruid : MonoBehaviour
{
    public int health;
    public int maxHealth = 1000;
    public int damage;
    public bool isDead;

    public Boss boss;

    private int random;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        damage = 0;
        isDead = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isDead == false)
            dealDamage();

        if (health <= 0)
            isDead = true;
    }

    public void dealDamage()
    {
        random = (int) Random.Range(5, 16);
        damage = random;
        boss.health -= damage;
    }

    public string toString()
    {
        return "Moonkin Druid: " + health + "\n";
    }


}
