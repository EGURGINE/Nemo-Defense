using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyObj;
    [SerializeField] private GameObject objs;
    [SerializeField] private int objNum;

    [SerializeField] private Stack<GameObject> enemys = new Stack<GameObject>();


    public bool isSpawn;

    private int spRadius = 3;
    private float posX;
    private float posY;

    [Header("Àû ½ºÅÝ")]
    public float enemy_dmg;
    public float enemy_hp;
    public float enemy_spd;

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
        for (int i = 0; i < objNum; i++)
        {
            GameObject obj = Instantiate(enemyObj);
            Push(obj);
        }
        isSpawn = true;
    }

    private void Update()
    {
        if (isSpawn == false) return;

        if (CNT >=maxCnt)
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
        float angle = Random.Range(0, 360);
        posX = Mathf.Cos(angle) * spRadius;
        posY = Mathf.Sin(angle) * spRadius;

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
}
