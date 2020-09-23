using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSpace : MonoBehaviour {
    public GameObject theProtoctile;
    public float shootTime;
    public Transform shootFrom;
    public int chanceShoot;
    float nextShootTime;
    Animator cannonAnim;

	// Use this for initialization
	void Start () {
        cannonAnim = GetComponent<Animator>();
        nextShootTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerStay2D (Collider2D other)
    {
        if (other.tag == "Player" && nextShootTime < Time.time)
        {
            nextShootTime = Time.time + shootTime;
            if(Random.Range(0,10)>=chanceShoot)
            {
                Instantiate(theProtoctile, shootFrom.position, Quaternion.identity);
            }
        }
    }
}
