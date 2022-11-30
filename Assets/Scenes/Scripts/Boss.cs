using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public bool mustPatrol = true;
    public bool mustTurn;
    public float walkSpeed;
    public int hp;
    private Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public int dir = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<Collider2D>().isTrigger = true;
        hp = 500;
    }
    private void Update()
    {
        if (mustPatrol)
        {
            Debug.Log("MUSTPATROLLL");
            Patrol();
        }
    }

    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            Debug.Log(Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer));
        }
    }

    void Patrol()
    {
        if (mustTurn)
        {
            Flip();
        }
        Debug.Log("PPP");
        rb.velocity = new Vector2(walkSpeed* 100 * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        //Destroy the coin if Object tagged Player comes in contact with it
        if (c2d.CompareTag("Wall"))
        {
            //Destroy coin
            Debug.Log("MUST TURN");
            mustTurn = true;
        }

        if (c2d.CompareTag("Bullet"))
        {
            //Destroy coin
            hp -= 50;
            if (hp < 0)
            {
                Destroy(transform.gameObject);
            }
            Debug.Log("Enemy Got Hit");
        }
    }

    public void SetHP(int x)
    {
        hp = x;
    }
}
