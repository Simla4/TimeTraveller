using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kursun2 : MonoBehaviour {
    public float sure;
	void Start () {
		
	}
	
	void Awake () {
        Destroy(gameObject, sure);
    }
}
