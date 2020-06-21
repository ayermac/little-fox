using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEagle : Enemy
{
    private Rigidbody2D rb;
    //private Animator anim;
    public Collider2D coll;

    public Transform upPoint, downPoint;
    public float flyHigh;
    private float upY, downY;
    private bool FlyDown = true;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();

        transform.DetachChildren();
        upY = upPoint.position.y;
        downY = downPoint.position.y;

        Destroy(upPoint.gameObject);
        Destroy(downPoint.gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        if (FlyDown)
        {
            rb.velocity = new Vector2(rb.velocity.x, -flyHigh);

            if (transform.position.y < downY)
            {
                FlyDown = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, flyHigh);

            if (transform.position.y > upY)
            {
                FlyDown = true;
            }
        }
    }
}
