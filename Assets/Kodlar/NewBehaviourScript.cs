using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    public float alive;
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        Invoke("Sure", alive);
    }
    void Sure() { Destroy(gameObject); }
}
