using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkMonster : Enemy, IShootAble
{
    float attackRange;
    public float AttackRange { get { return attackRange; } set { attackRange = value; } }
    public Player player;

    [field: SerializeField] Transform spawnPoint;
    public Transform SpawnPoint { get { return spawnPoint; } set { spawnPoint = value; } }

    [field: SerializeField] GameObject bullet;
    public GameObject Bullet { get { return bullet; } set { bullet = value; } }

    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }

    void Start()
    {
        WaitTime = 0.0f;
        ReloadTime = 3.0f;
        DamageHit = 30;
        AttackRange = 8;
        player = GameObject.FindObjectOfType<Player>();
    }

    void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
        Behavior();
    }

    public override void Behavior()
    {
        Vector2 direction = player.transform.position - transform.position;
        float distance = direction.magnitude;
        if (distance <= attackRange)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (WaitTime >= ReloadTime)
        {
            anim.SetTrigger("Shoot");
            GameObject obj = Instantiate(bullet, spawnPoint.position, Quaternion.identity);
            Rock rockScript = obj.GetComponent<Rock>();

            rockScript.InitWeapon(20, this);
            WaitTime = 0;
        }

    }
}
