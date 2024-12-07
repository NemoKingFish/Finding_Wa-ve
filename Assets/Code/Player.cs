using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    void Start()
    {
        InitHealthBar(60);
        Init(60);
    }
    public void OnHitWith(Enemy enemy)
    {
        TakeDamage(enemy.DamageHit);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            OnHitWith(enemy);
        }
    }
   
}
