using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using static UnityEngine.GraphicsBuffer;

public class Shot : MonoBehaviour
{
    [SerializeField] private Player Player;
    List<GameObject> enemyList = new List<GameObject>();
    private GameObject target;

    private float bulletCnt = 0;
    private float bulletShotSpd => Player.state.shotSpd;

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
        if (enemyList.FirstOrDefault() != null)
        {
            shotPos.LookAt(target.transform.position);
            BulletSet();
        }
        else bulletCnt = bulletShotSpd;
    }

    private void BulletSet()
    {
        Bullet bullet = Instantiate(bulletObj);
        bullet.transform.position = shotPos.position;
        bullet.SetBullet(Player.state.dmg, bulletSpd, shotPos.forward);
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
            if(enemyList.FirstOrDefault() == null) isShot = false;
        }
    }
}
