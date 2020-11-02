using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Priest : MonoBehaviour
{
    public int health;
    public int maxHealth = 1000;
    public int mana;
    public int maxMana = 1000;
    public bool isDead;

    public Warrior tank;
    public Rogue damageDealer1;
    public Mage damageDealer2;
    public MoonkinDruid damageDealer3;

    private int random;
    private Text[] hold;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        mana = maxMana;
        isDead = false;
        hold = gameObject.GetComponentsInChildren<Text>();
    }

    void FixedUpdate()
    {
        if (isDead == false)
            performHeals();
        
        if (health <= 0)
            isDead = true;

        hold[0].text = "" + health;
        hold[1].text = "" + mana;
    }

    // random damage or self heal
    public void smallHeal() {
        random = (int) Random.Range(0, 6);

        switch (random) {

            case 0:// Rogue
                if (damageDealer1.health < damageDealer1.maxHealth)
                {
                    damageDealer1.health += 15;
                }
                if (damageDealer1.health >= damageDealer1.maxHealth)
                    damageDealer1.health = damageDealer1.maxHealth;
                break;
            case 1: // Mage
                if (damageDealer2.health < damageDealer2.maxHealth)
                {
                    damageDealer2.health += 15;
                }
                if (damageDealer2.health >= damageDealer2.maxHealth)
                    damageDealer2.health = damageDealer2.maxHealth;
                break;
            case 2: // Moonkin Druid
                if (damageDealer3.health < damageDealer3.maxHealth)
                {
                    damageDealer3.health += 15;
                }
                if (damageDealer3.health >= damageDealer3.maxHealth)
                    damageDealer3.health = damageDealer3.maxHealth;
                break;
            case 3:
            case 4:
            case 5:
                if (health < maxHealth)
                {
                    health += 15;
                }
                if (health >= maxHealth)
                    health = maxHealth;
                break;
        }
    }

    // tank heal
    public void bigHeal()
    {
        if(tank.health < tank.maxHealth)
        {
            tank.health += 20;
        }

        if (tank.health >= tank.maxHealth)
            tank.health = tank.maxHealth;
    }

    // calculates heal logic
    private void performHeals()
    {
        if (mana >= 8)
        {
            bigHeal();
            mana -= 8;
        }
        if (mana >= 5)
        {
            smallHeal();
            mana -= 5;
        }
        mana = +2;
    }

    // to string for printing to cvs
    public string toString()
    {
        return "Priest: " + health + "\n";
    }
}
