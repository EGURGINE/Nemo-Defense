using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : Singleton<Spawner>
{
    [SerializeField] private GameObject enemyObj;
    [SerializeField] private GameObject objs;
    [SerializeField] private int objNum;

    [SerializeField] private Stack<GameObject> enemys = new Stack<GameObject>();

    private bool isSpawn => GameManager.Instance.isSpawnTrun;

    private int spRadius = 5;
    private float posX;
    private float posY;

    [Header("적 스텟")]
    private float enemy_dmg = 1;
    private float enemy_hp = 5;
    private float enemy_spd = 1;

    [SerializeField] private TextMeshProUGUI waveEnemyDmgTxt;
    [SerializeField] private TextMeshProUGUI waveEnemyHPTxt;

    [SerializeField] private float maxCnt;
    private float cnt;
    private float CNT
    {
        get { return cnt; }
        set 
        { 
            cnt = value;
        }
    }

    private void Start()
    {
        TextSet();
        for (int i = 0; i < objNum; i++)
        {
            GameObject obj = Instantiate(enemyObj);
            Push(obj);
        }
    }

    private void Update()
    {
        if (isSpawn == false) return;

        if (CNT >= maxCnt)
        {
            CNT = 0;
            Spawn();
        }
        CNT += Time.deltaTime;
    }

    public void Push(GameObject obj)
    {
        enemys.Push(obj);
        obj.transform.parent = objs.transform;
        obj.SetActive(false);
    }

    
    private void Pop()
    {
        //플레이어 기준 랜덤한 지름에 스폰
        
        Vector3 playerPos = Player.Instance.gameObject.transform.position;
        float angle = Random.Range(0, 360);
        posX = playerPos.x + Mathf.Cos(angle) * spRadius;
        posY = playerPos.y + Mathf.Sin(angle) * spRadius;

        GameObject obj = enemys.Pop();
        obj.transform.parent = null;
        obj.transform.position = new Vector3(posX ,posY , 0);
        obj.GetComponent<Enemy>().StartSet(enemy_dmg, enemy_hp, enemy_spd);
        obj.SetActive(true);
    }

    private void Spawn()
    {
        Pop();
    }

    // 적 능력치 증가
    public void EnemyUp()
    {
        enemy_dmg += 0.1f;
        enemy_hp += 0.5f;
        TextSet();
    }

    // 스폰하는 적 스텟 표시
    private void TextSet() 
    {
        waveEnemyDmgTxt.text = enemy_dmg.ToString();
        waveEnemyHPTxt.text = enemy_hp.ToString();
    }

}
