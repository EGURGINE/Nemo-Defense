using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using static UnityEngine.GraphicsBuffer;

public class Shot : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyList = new List<GameObject>();
    private GameObject target;

    private float bulletCnt = 0;
    private float bulletShotSpd => Player.Instance.state.shotSpd;

    private bool isShot = false;

    [SerializeField] private Transform shotPos;
    [SerializeField] private Bullet bulletObj;

    private float bulletSpd = 5;

    private void Update()
    {
        
        if (isShot == false) return;
        
        if (bulletCnt >= bulletShotSpd)
        {
            bulletCnt = 0;
            ShotBullet();
        }
        bulletCnt += Time.deltaTime;
    }

    private void ShotBullet()
    {
        if (enemyList.Count > 0)
        {
            shotPos.LookAt(target.transform.position);
            BulletSet();
        }
    }

    private void BulletSet()
    {
        Bullet bullet = Instantiate(bulletObj);
        bullet.transform.position = shotPos.position;
        bullet.SetBullet(Player.Instance.state.dmg, bulletSpd, shotPos.forward);
    }

    private GameObject DistanceEnemy()
    {
        var neareastObject = enemyList
        .OrderBy(obj =>
        {
            return Vector3.Distance(transform.position, obj.transform.position);
        }).FirstOrDefault();

        return neareastObject;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemyList.Add(collision.gameObject);
            target = DistanceEnemy();
            isShot = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemyList.Remove(collision.gameObject);
            if(enemyList.Count < 1) isShot = false;
        }
    }
}
