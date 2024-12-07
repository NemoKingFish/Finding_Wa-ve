using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : Enemy
{
    [SerializeField] Vector2 velocity;
    public Vector2 Velocity { get { return velocity; } set { velocity = value; } }

    [SerializeField] Transform[] movePoints;

    void Start()
    {
        velocity = new Vector2(-1.0f, 0.0f);
        DamageHit = 20;
    }

    public override void Behavior()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        if (rb.position.x >= movePoints[1].position.x && velocity.x > 0)
        {
            Flip();
        }

        if (rb.position.x <= movePoints[0].position.x && velocity.x < 0)
        {
            Flip();
        }
    }
    void FixedUpdate()
    {
        Behavior();
    }
    void Flip()
    {
        velocity.x *= -1;
        Vector3 charScale = transform.localScale;
        charScale.x *= -1;
        transform.localScale = charScale;
    }
}
