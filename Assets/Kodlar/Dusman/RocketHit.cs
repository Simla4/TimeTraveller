using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketHit : MonoBehaviour {

    public float hasar;
    Kursun myPc;
    public GameObject Effect;

	void Awake () {
        myPc = GetComponentInParent<Kursun>();
	}
	
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("shootable"))
        {
            myPc.removeForce();
            Instantiate(Effect, transform.position, transform.rotation);
            Destroy(gameObject);   
        }
        if (other.tag == "Tuzak")
        {
            EnemyHealth can = other.gameObject.GetComponent<EnemyHealth>();
            can.AddDamage(hasar);
        }
     
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("shootable"))
        {
            myPc.removeForce();
            Instantiate(Effect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (other.tag == "Tuzak")
        {
            EnemyHealth can = other.gameObject.GetComponent<EnemyHealth>();
            can.AddDamage(hasar);
        }
    }
}
