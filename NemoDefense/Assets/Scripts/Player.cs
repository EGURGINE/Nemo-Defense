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
    public float moneyBonus;
    public float waveMoney;
}


public class Player : Singleton<Player>
{
    public State state;

    [SerializeField] private TextMeshProUGUI dmgTxt;

    [SerializeField] private TextMeshProUGUI hpTxt;
    [SerializeField] private Image hpImg;

    public Coroutine regenerationCoroutine;

    private float hp;

    public float HP 
    { 
        get { return hp; }
        set
        {
            hp = value;

            if(hp > state.hp) hp = state.hp;

            hpTxt.text = $"{hp}/{state.hp}";
            hpImg.fillAmount = hp / state.hp;

            if (hp <= 0)
            {
                hp = 0;
                Die();
            }
        }
    }

    public float DMG
    {
        get { return state.dmg; }
        set 
        {
            state.dmg = value;
            dmgTxt.text = state.dmg.ToString();
        }
    }

    private void Start()
    {
        StartSET();
    }

    public IEnumerator Regeneration()
    {
        yield return new WaitForSeconds(1f);
        HP += state.regeneration;
        regenerationCoroutine = StartCoroutine(Regeneration());
    }

    public void StartSET()
    {
        HP = state.hp;

        if (state.regeneration > 0) StartCoroutine(Regeneration());
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
