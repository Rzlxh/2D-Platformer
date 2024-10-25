using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour

{
    Rigidbody2D projectileRB;
    PlayerMovement playerScript;

    float xSpeed;

    public float projectileSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        projectileRB = GetComponent<Rigidbody2D>();
        playerScript = FindObjectOfType<PlayerMovement>();
        xSpeed = playerScript.transform.localScale.x * projectileSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        projectileRB.velocity = new Vector2(xSpeed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Enemy")
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
