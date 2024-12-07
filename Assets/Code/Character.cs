using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected int health;
    public int Health { get { return health; } set { health = value; } }

    public Animator anim;
    public Rigidbody2D rb;

    public HealthBar healthBar;
    public int maxHealth;
    public int currentHealth;

    public virtual void Init(int newHealth)
    {
        health = newHealth;
        newHealth = maxHealth;
        //get components for prefabs
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public bool IsDead()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
            return true;
        }
        else return false;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        health -= damage;
        healthBar.SetHealth(currentHealth);
        Debug.Log($"{this.name} took {damage} damage now health is {this.health}");
        IsDead();
    }

    public void InitHealthBar(int initialHealth)
    {
        maxHealth = initialHealth;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(health);
        //healthBar.UpdatsHealthBar(maxHealth);     
    }
    public void TakePotion(int healthIncrease)
    {
        health += healthIncrease;
        currentHealth += healthIncrease;
        healthBar.SetHealth(currentHealth);
        if (health > maxHealth)
        {            
            health = maxHealth;
        }          
        Debug.Log($"Health increased! Current health: {this.health}");
    }

}
