using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kursun : MonoBehaviour {

    //Kurşunun ilerleme hızını ve ilerlerken tere düşmemesini sağladık
    public float hiz;
    Rigidbody2D kursun;

	void Awake ()
    {
        kursun = GetComponent<Rigidbody2D>();
        kursun.AddForce(new Vector2(1, 0) * hiz, ForceMode2D.Impulse);
    }
	
	void Update () {
		
	}
    public void removeForce()
    {
        kursun.velocity = new Vector2(0, 0);
    }
    
}
