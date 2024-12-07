using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Weapon
{
    Rigidbody2D rb2d;
    Vector2 force;
    [SerializeField] float speed;

    void Start()
    {
        InitWeapon(20, this.shooter);
        force = new Vector2(GetShootDirection() * 100, 400);
    }
    private void FixedUpdate()
    {
        Move();
    }

    public override void Move()
    {
        float newX = transform.position.x + speed * Time.fixedDeltaTime;
        float newY = transform.position.y;
        Vector2 newPosition = new Vector2(newX, newY);
        transform.position = newPosition;
    }

    public override void OnHitWith(Character character)
    {
        
        if (character is Player)
        {
            character.TakeDamage(this.Damage);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        OnHitWith(other.GetComponent<Character>());
        Destroy(this.gameObject,1 );
    }
}
