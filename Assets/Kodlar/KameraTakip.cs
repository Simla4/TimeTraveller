using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour {

    public Transform k;
    public float x, y;//Kameranın takip edeceği koordinatların belirtmek için
    void Start ()
    {
        k = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	void Update () {
        transform.position = new Vector3(k.position.x + x, k.position.y + y,-1);
	}
}
