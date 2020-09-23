using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasIlerleme : MonoBehaviour
{
    public float hiz;
    Animator enemyAnimator;
    public GameObject enemyGraphic;
    bool canFlip = true;
    bool facingRight = false;
    float flipTime = 5f;
    float nextFlipChange = 0f;
    public float ChargeTime;
    float startChargeTime;
    bool charcing;
    Rigidbody2D enemyRB;

    // Use this for initialization
    void Start()
    {
        enemyAnimator = GetComponentInChildren<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFlipChange)
        {
            if (Random.Range(1, 10) > 5) flipFacing();
            nextFlipChange = Time.time + flipTime;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (facingRight && other.transform.position.x < transform.position.x) flipFacing();
            else if (!facingRight && other.transform.position.x > transform.position.x)
                flipFacing();
            canFlip = false;
            charcing = true;
            startChargeTime = Time.time + ChargeTime;
        }

    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (startChargeTime >= Time.time)
            {
                if (!facingRight) enemyRB.AddForce(new Vector2(-1, 0) * hiz);
                else enemyRB.AddForce(new Vector2(1, 0) * hiz);
                enemyAnimator.SetBool("IsCharcing", charcing);
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canFlip = true;
            charcing = false;
            enemyRB.velocity = new Vector2(0f, 0f);
            enemyAnimator.SetBool("IsCharcing", charcing);
        }
    }
    void flipFacing()
    {
        if (!canFlip) return;
        float facingX = enemyGraphic.transform.localScale.x;
        facingX *= -1f;
        enemyGraphic.transform.localScale = new Vector3(facingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);
        facingRight = !facingRight;

    }
}
