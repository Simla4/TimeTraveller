using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConroler : MonoBehaviour {

    public float hiz,ziplama,h;
    public bool yerdemi, ciftZiplama;
    Rigidbody2D agirlik;
    Animator anim;//Yürüme Animasyon ile birlikte hareket etmesi için
    public int can, maxcan;
    public GameObject[] canlar;
    //Silah için
    public Transform silah;
    public GameObject bullet;
    float fireRate;
    float netxFire;
    //Level Atlama
    public int levelId;
    public int yanma;
    //sesler
    public AudioClip[] sesler;
    void Start () {
        agirlik = GetComponent<Rigidbody2D>();//Agirlik'i Rigidbody'e eşitledik
        anim = GetComponent<Animator>();
        can = maxcan;
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (yerdemi)
            {
                agirlik.AddForce(Vector2.up * ziplama);
                ciftZiplama = true;
            }
            else
            {
                if (ciftZiplama)
                {
                    ciftZiplama = false;
                    agirlik.AddForce(Vector2.up * ziplama / 2);
                }
            }
        }
        if (can <= 0)
            Olme();
        //Oyuncunun silahı ateşlemesi için 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fireGun();
            
        }
	}
    void fireGun()
    {
        if (Time.time > netxFire)
        {
            netxFire = Time.time + fireRate;
            Instantiate(bullet, silah.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }
    
    void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        //agirlik.AddForce(Vector3.right * h * hiz);
        if (h > 0)
        {
            transform.Translate(h * hiz * Time.deltaTime, 0, 0);
        }
        if(h<0)
        {
            transform.Translate(h * hiz * Time.deltaTime, 0, 0);
        }
        anim.SetFloat("Speed", Mathf.Abs(h));
        anim.SetBool("Yerde", yerdemi);
        
    }
    void CanSistemi()
    {
        for(int i = 0; i < maxcan; i++)
        {
            canlar[i].SetActive(false);
        }
        for (int i = 0; i < can; i++)
        {
            canlar[i].SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Can")
        {
            if (can != maxcan)
            {
                can++;
                CanSistemi();
                Destroy(other.gameObject);
                GetComponent<AudioSource>().PlayOneShot(sesler[1]);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D nesne)
    {
        if(nesne.gameObject.tag== "Tuzak")//Tuzak tagını buldurduk
        {
            can--;
            agirlik.AddForce(Vector2.up * ziplama);
            GetComponent<SpriteRenderer>().color = Color.red;
            
            Invoke("Duzelt", 0.5f);
            CanSistemi();
            GetComponent<AudioSource>().PlayOneShot(sesler[2]);
        }
        if (nesne.gameObject.tag == "Tardis")
        {
            Application.LoadLevel(levelId);
        }
        if (nesne.gameObject.tag == "LevelSifir")
        {
            Application.LoadLevel(yanma);
        }
    }
    void CanEkle(Collider2D other)
    {
        if (other.gameObject.tag == "Can")
        {
            if(can!=maxcan)
            {
                can++;
                CanSistemi();
                Destroy(other.gameObject);
                
            }
        }
    }
    void Duzelt()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    void Olme()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
