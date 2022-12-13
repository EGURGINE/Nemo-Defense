using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float dmg;
    float spd;
    Vector3 dir;
    Rigidbody2D rb => GetComponent<Rigidbody2D>();
    private void Start()
    {
        rb.velocity = dir * spd;
        Destroy(gameObject, 1f);
    }
    public void SetBullet(float _dmg, float _spd, Vector3 _dir)
    {
        dmg = _dmg;
        spd = _spd;
        dir = _dir;
    }
}
