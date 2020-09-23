using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ziplama : MonoBehaviour {
    PlayerConroler z;

    void Start () {
        z = transform.root.gameObject.GetComponent<PlayerConroler>();
    }
    void OnTrigger2D()
    {
        z.yerdemi = true;
    }
    void OnTriggerStay2D()
    {
        z.yerdemi = true;
    }
    void OnTriggerExit2D()
    {
        z.yerdemi = false;
    }

    void Update () {
		
	}
}
