using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    float xMultiplier = 200;
    [SerializeField] Transform GroundCheckCollider;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] int hp;
    float jumpPower = 300;

    const float groundCheckRadius = 0.2f;
    private float inputAxis;
    private Rigidbody2D rb;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] int jumpAbility;
    public static int jumpBaseAbility;
    bool faceRight = true;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpBaseAbility = 1;
        hp = 100;
    }

    // Update is called once per frame
    void Update()
    {
        inputAxis = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown("space"))
        {
            Jump();
        }

    }
    void FixedUpdate()
    {
        GroundCheck();
        Move(inputAxis);
        IsDeath();
    }

    void GroundCheck()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
        {
            isGrounded = true;
            jumpAbility = jumpBaseAbility;
        }
    }

    void Jump()
    {
        if (isGrounded || jumpAbility > 1)
        {
            if(jumpAbility > -1)
                jumpAbility--;
            rb.AddForce(new Vector2(0f, jumpPower));
        }
    }
    void Move(float dir)
    {
        float xPower = dir * xMultiplier * Time.fixedDeltaTime;
        Vector2 targetVelocity = new Vector2(xPower, rb.velocity.y);
        rb.velocity = targetVelocity;

        if (faceRight && dir < 0)
        {
            transform.localScale = new Vector3(-1*transform.localScale.x, transform.localScale.y, 1);
            faceRight = false;
        }
        //If looking left and clicked right (flip to rhe right)
        else if (!faceRight && dir > 0)
        {
            transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, 1);
            faceRight = true;
        }
    }

    void IsDeath()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetJumpBaseAbility(int x)
    {
        jumpBaseAbility = x;
    }

    public void TakeDamage(int damage)
    {
        hp = -damage;
    }

}
