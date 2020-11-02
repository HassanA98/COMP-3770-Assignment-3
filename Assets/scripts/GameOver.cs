using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Boss boss;
    public Priest healer;
    public Warrior tank;
    public Rogue dmg1;
    public Mage dmg2;
    public Druid dmg3;

    private GameObject btn;

    // Start is called before the first frame update
    void Start()
    {
        btn = GameObject.Find("Exit");
    }

    // Update is called once per frame
    void Update()
    {
        if(boss.isDead || healer.isDead || tank.isDead || dmg1.isDead || dmg2.isDead || dmg3.isDead)
        {
            boss.isDead = healer.isDead = tank.isDead = dmg1.isDead = dmg2.isDead = dmg3.isDead = true;
            btn.SetActive(true);
        }
        else
        {
            btn.SetActive(false);
        }
    }
}
