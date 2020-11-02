using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warrior : MonoBehaviour
{
    public int health;
    public int maxHealth = 3000;
    public int damage;
    public bool isDead;

    public Boss boss;

    private int random;
    private Text[] hold;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        damage = 5;
        isDead = false;
        hold = gameObject.GetComponentsInChildren<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDead == false)
            dealDamage();

        if (health <= 0)
            isDead = true;

        hold[0].text = "" + health;
        hold[1].text = "" + damage;
    }

    public void dealDamage()
    {
        boss.health -= damage;
    }

    public string toString()
    {
        return "Warrior: " + health + "\n";
    }
}
