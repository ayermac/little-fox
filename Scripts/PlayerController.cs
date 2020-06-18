using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public Collider2D coll;

    public float speed;
    public float jumpforce;
    public LayerMask ground;

    private bool SpaceKeyDown = false;
    public int Cherry;
   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Jump();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        SwitchAnim();
    }

    void Movement()
    {
        float horizontalmovel = Input.GetAxis("Horizontal");
        float facedircation = Input.GetAxisRaw("Horizontal");

        // 角色移动
        if (horizontalmovel != 0)
        {
            rb.velocity = new Vector2(horizontalmovel * speed * Time.deltaTime, rb.velocity.y);
            anim.SetFloat("running", Mathf.Abs(facedircation));
        }
        if (facedircation != 0)
        {
            transform.localScale = new Vector3(facedircation, 1, 1);
        }

        // 角色跳跃
        if (SpaceKeyDown)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce * Time.deltaTime);
            anim.SetBool("jumping", true);
            SpaceKeyDown = false;
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            SpaceKeyDown = true;
        }
    }

    void SwitchAnim()
    {
        anim.SetBool("idle", false);
        if (anim.GetBool("jumping"))
        {
            if (rb.velocity.y < 0)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
        } else if (coll.IsTouchingLayers(ground))
        {
            anim.SetBool("falling", false);
            anim.SetBool("idle", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collection")
        {
            Destroy(collision.gameObject);
            Cherry++;
        }
    }
}
