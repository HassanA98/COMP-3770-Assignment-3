using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Druid : MonoBehaviour
{
    public int health;
    public int maxHealth = 1000;
    public int damage;
    public bool isDead;

    public Boss boss;

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
        if(isDead == false)
            dealDamage();

        if (health <= 0)
            isDead = true;

        hold[0].text = "" + health;
        hold[1].text = "" + damage;
    }

    public void dealDamage()
    {
        random = (int) Random.Range(5, 16);
        damage = random;
        boss.health -= damage;
    }

    public string toString()
    {
        return "Druid: " + health + "\n";
    }


}
