using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanCan : MonoBehaviour {

    public float maxCan;
    float can;
	void Start () {
        can = maxCan;
	}
	
	void Update () {
		
	}
    public void AddDamage(float damage)
    {
        can -= damage;
        if (can <= 0)
            makeDead();
    }
    void makeDead()
    {
        Destroy(gameObject);
    }
}
