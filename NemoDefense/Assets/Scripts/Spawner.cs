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
            obj.transform.parent = objs.transform;
            enemys.Push(obj);
        }
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
        GameObject obj = enemys.Pop();
        obj.transform.parent = null;
        obj.SetActive(true);
    }

    private void Spawn()
    {

    }
}
