using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovemet2 : MonoBehaviour
{

    Rigidbody2D enemyBody2D;
    public float hiz;
    bool isGround;
    Transform groundCheck;
    const float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public bool moveRight;
    void Start()
    {
        enemyBody2D = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("Dusman");
    }

    // Update is called once per frame
    void Update()
    {
        

        enemyBody2D.velocity = (moveRight) ? new Vector3(hiz, 0) : new Vector3(-hiz, 0);

    }
    void OnCollisionEnter2D(Collision2D nesne)
    {
        if (nesne.gameObject.tag == "Tuzak")
        {
            moveRight = !moveRight;
            transform.localScale = (moveRight) ? new Vector2(-1, 1) : new Vector2(1, 1);
        }

    }
}
