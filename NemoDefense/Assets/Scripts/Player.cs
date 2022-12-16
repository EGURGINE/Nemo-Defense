using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct State
{
    [Header("ATK")]

    public float dmg;
    public float shotSpd;

    [Header("DEF")]

    public float hp;
    public float regeneration;

    [Header("UTY")]

    public float killMoney;
    public int waveMoney;
}


public class Player : Singleton<Player>
{
    public State state;

    private float maxHp => state.hp;
    public float HP 
    { 
        get { return state.hp; }
        set
        {
            state.hp = value;

            if (state.hp <= 0) Die();
        }
    }


    public void StartSET()
    {
        HP = maxHp;
    }

    public void Die()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            HP -= collision.GetComponent<Enemy>().state.dmg;
        }
    }

}
