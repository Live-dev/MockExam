using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2.6f;
    private Rigidbody2D body;
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();

    }


    void FixedUpdate()
    {
        Move();
    }

    //moves the player towards left
    public void moveleft()
    {
        body.velocity = new Vector2(-speed, body.velocity.y);
    }
    //moves the player towards right 
    public void moveright()
    {
        body.velocity = new Vector2(speed, body.velocity.y);
    }
   
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        if (x > 0)
        {
            moveright();
        }
        if (x < 0)
        {
            moveleft();

        }
    }

    public void Platformmove(float x)
    {
        body.velocity = new Vector2(x, body.velocity.y);

    }
}
