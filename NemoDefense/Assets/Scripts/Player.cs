using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
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

    [SerializeField] private TextMeshProUGUI hpTxt;
    [SerializeField] private Image hpImg;

    public float MaxHP;

    public float HP 
    { 
        get { return state.hp; }
        set
        {
            state.hp = value;

            hpTxt.text = $"{state.hp}/{MaxHP}";
            hpImg.fillAmount = state.hp / MaxHP;

            if (state.hp <= 0)
            {
                state.hp = 0;
                Die();
            }
        }
    }

    [SerializeField] private TextMeshProUGUI dmgTxt;
    public float DMG
    {
        get { return state.dmg; }
        set 
        {
            state.dmg = value;
            dmgTxt.text = state.dmg.ToString();
        }
    }

    public void StartSET()
    {
        HP = MaxHP;
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
