using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float horizontalmovel;
        horizontalmovel = Input.GetAxis("Horizontal");

        if (horizontalmovel != 0)
        {
            rb.velocity = new Vector2(horizontalmovel * speed, rb.velocity.y);
        }
    }
}
