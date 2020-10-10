using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorKontrol : MonoBehaviour
{
    float donusHizi;
    kraliceKontrol kralice;
    Rigidbody2D fizik;


    void Start()
    {

        donusHizi = Random.Range(2, 8);
        kralice = GameObject.FindGameObjectWithTag("kralice").GetComponent<kraliceKontrol>();
        fizik = GetComponent<Rigidbody2D>();
        fizik.AddForce(kralice.getYon() * 200000);
    }


    void OnCollisionEnter2D(Collision2D col)
    {

     
            if (col.gameObject.tag == "duvar" || col.gameObject.tag == "dusman" || col.gameObject.tag == "karakter" || col.gameObject.tag == "meteor")
            {

            Destroy(gameObject);

        }

          


    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if ( col.gameObject.tag == "karadelik" )
        {

            Destroy(gameObject);

        }
    }


    void FixedUpdate()
    {
        transform.Rotate(0, 0, donusHizi);

    }
}
