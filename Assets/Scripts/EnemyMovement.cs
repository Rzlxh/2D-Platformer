using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D enemyRB;
    public float enemySpeed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRB.velocity = new Vector2(enemySpeed, 0f);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        enemySpeed = -enemySpeed;
        FlipEnemyFacing();
    }

    void FlipEnemyFacing()
    {
        transform.localScale = new Vector2(Mathf.Sign(enemyRB.velocity.x), 1f);
    }
}
