using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] int damage;    
    public int Damage { get { return damage; } set { damage = value; } }

    public IShootAble shooter;

    public abstract void OnHitWith(Character character);
    public abstract void Move();

    public void InitWeapon(int newDamage, IShootAble newOwner)
    {
        Damage = newDamage;
        shooter = newOwner;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        OnHitWith(other.GetComponent<Character>());
        Destroy(this.gameObject, 5f);
    }
    public int GetShootDirection()
    {
        float shootDir = shooter.SpawnPoint.position.x - shooter.SpawnPoint.parent.position.x;
        // Debug to check shoot direction
        Debug.Log($"Shoot Direction Value: {shootDir}");
        if (shootDir > 0)
            return 1;  // Right direction
        else
            return -1; // Left direction
    }
}
