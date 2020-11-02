using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int health;
    public int maxHealth = 4500;
    public int damage;
    public bool isDead;

    public Priest healer;
    public Warrior tank;
    public Rogue dmg1;
    public Mage dmg2;
    public Druid dmg3;

    private int random;
    private Text[] hold;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        damage = 0;
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
        // dmg healer
        random = (int)Random.Range(5, 21);
        damage = random;
        healer.health -= damage;

        // dmg rogue
        random = (int)Random.Range(5, 21);
        damage = random;
        dmg1.health -= damage;

        //dmg Mage
        random = (int)Random.Range(5, 21);
        damage = random;
        dmg2.health -= damage;

        //dmg Druid
        random = (int)Random.Range(5, 21);
        damage = random;
        dmg3.health -= damage;

        //dmg Tank
        random = (int)Random.Range(45, 56);
        damage = random;
        tank.health -= damage;

    }

    public string toString()
    {
        return "Boss: " + health + "\n";
    }
}
