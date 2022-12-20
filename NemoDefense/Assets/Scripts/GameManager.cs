using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameManager : Singleton<GameManager>
{
    [Header("Money")]
    [SerializeField] private TextMeshProUGUI moneyTxt;
    private float money;
    public float Money
    {
        get { return money; }
        set
        {
            money = value;
            moneyTxt.text = money.ToString();
        }
    }

    [Header("Wave")]
    public int waveCnt = 1;
    [SerializeField] private TextMeshProUGUI waveCntTxt;

    [SerializeField] private Color[] waveColor = new Color[2];
    [SerializeField] private Image waveValue;

    public bool isSpawnTrun = true;

    public const float maxWave = 10f;
    private float wave;
    public float Wave
    {
        get { return wave; }
        set 
        {
            wave = value;
            if (wave > maxWave)
            {
                if (isSpawnTrun == true)
                {
                    waveValue.color = waveColor[1];
                    isSpawnTrun = false;
                }
                else
                {
                    waveValue.color = waveColor[0];
                    isSpawnTrun = true;
                    waveCnt++;
                    waveCntTxt.text = waveCnt.ToString();
                    Spawner.Instance.EnemyUp();
                    Money += Player.Instance.state.waveMoney;
                }
                wave = 0;
            }
            waveValue.fillAmount = wave / maxWave;
        }
    }

    private void Start()
    {
        Player.Instance.StartSET();
    }
    private void Update()
    {
        Wave += Time.deltaTime;
    }
}
