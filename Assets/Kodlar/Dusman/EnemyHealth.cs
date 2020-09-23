using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public float maxcan;
    float can;
    public bool drops;
    public GameObject theDrop;

	// Use this for initialization
	void Start () {
        can = maxcan;
	}
    public void AddDamage(float hasar)
    {
        can -= hasar;
        if (can <= 0)
            makeDead();
    }
	void makeDead()
    {
        Destroy(gameObject);
        if (drops)
            Instantiate(theDrop, transform.position, transform.rotation);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
