using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public State state;

    private float HP
    {
        get { return state.hp; }
        set 
        {
            state.hp = value;

            if (state.hp <= 0) Die();
        }
    }

    private Rigidbody2D rb => GetComponent<Rigidbody2D>();

    private void Die()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            HP -= collision.GetComponent<Bullet>().dmg;
        }
    }
}
