using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rb;
    Animator anim;
    CapsuleCollider2D cc;
    BoxCollider2D feetCollider;

    public float runSpeed = 10f;
    public float jumpSpeed = 20f;
    public Vector2 deathFall = new Vector2(20f, 20f);
    public GameObject projectile;
    public Transform projectileSpawnPoint;

    bool isAlive = true;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        cc = GetComponent<CapsuleCollider2D>();
        feetCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isAlive)
        {
            return;
        }
        
        Run();
        FlipSprite();
        Death();
    }

    void OnFire(InputValue value)
    {
         if(!isAlive)
        {
            return;
        }

        Instantiate(projectile, projectileSpawnPoint.position, transform.rotation);
    }

    void OnMove(InputValue value)
    {
         if(!isAlive)
        {
            return;
        }
        
        moveInput = value.Get<Vector2>();
        //Debug.Log(moveInput);
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;

        bool playerHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        anim.SetBool("isRunning", playerHorizontalSpeed);

    }

    void FlipSprite()
    {
        bool playerHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if (playerHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
        
    }

    void OnJump(InputValue value)
    {
         if(!isAlive)
        {
            return;
        }
        
        if (!feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        
        if (value.isPressed)
        {
            rb.velocity += new Vector2(0f, jumpSpeed);
        }

    }

    void Death()
    {
        if (cc.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            isAlive = false;
            anim.SetTrigger("Death");
            rb.velocity = deathFall;
            FindObjectOfType<GameManager>().ProcessPlayerDeath();
        }        
    }
}
