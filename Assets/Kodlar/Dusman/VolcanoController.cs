using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoController : MonoBehaviour {

    public float sporeSpeedHight;
    public float sporeSpeedLow;
    public float sporeAngle;
    public float sporeTorqueAngle;

    Rigidbody2D sporeRB;
	// Use this for initialization
	void Start () {
        sporeRB = GetComponent<Rigidbody2D>();
        sporeRB.AddForce(new Vector2(Random.Range(-sporeAngle, Random.Range(sporeSpeedLow, sporeSpeedHight)),1));
        sporeRB.AddTorque(Random.Range(-sporeTorqueAngle, sporeTorqueAngle));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
