using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sarkit : MonoBehaviour {
    Rigidbody2D enemyBody2D;
    Transform groundCheck;
    public bool moveRight;
    void Start()
    {
        enemyBody2D = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("buzul");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D nesne)
    {
        if (nesne.gameObject.tag == "Buz")
        {
            moveRight = true;
            if(moveRight)
            {
                moveRight = !moveRight;
                nesne.rigidbody.gravityScale = 5;
            }
            else
                nesne.rigidbody.gravityScale = 0;

        }
        
    }
}
