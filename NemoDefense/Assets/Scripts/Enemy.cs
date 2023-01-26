using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public State state;

    Transform target => Player.Instance.gameObject.transform;

    private bool isMove;

    private float spd;
    private float HP
    {
        get { return state.hp; }
        set 
        {
            state.hp = value;

            if (state.hp <= 0) Die();
        }
    }

    private void Update()
    {
        if (isMove == false) return;
        transform.position = Vector2.MoveTowards(transform.position, target.position, spd * Time.deltaTime);
    }

    public void StartSet(float _dmg, float _hp, float _spd)
    {
        state.dmg = _dmg;
        HP = _hp;
        spd = _spd;

        isMove = true;
    }

    private void Die()
    {
        GameManager.Instance.Money += Player.Instance.state.moneyBonus;
        isMove = false;
        Spawner.Instance.Push(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            HP -= collision.GetComponent<Bullet>().dmg;
        }
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().HP -= state.dmg;
        }
    }
}
