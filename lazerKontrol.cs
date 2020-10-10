using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazerKontrol : MonoBehaviour
{
    dusmanKontrol dusman;
    Rigidbody2D fizik;

    void Start()
    {


        fizik = GetComponent<Rigidbody2D>();
        dusman = transform.parent.GetComponent<dusmanKontrol>();
        fizik.AddForce(dusman.getYon() * 1000);
        float lazerYonDerece = Vector3.Angle(new Vector3(0.0f, 1.0f, 0.0f), dusman.getYon());


        if (dusman.getYon().x < 0.0f)
        {
            lazerYonDerece = -lazerYonDerece;
            lazerYonDerece = lazerYonDerece + 360;
        }

        transform.rotation = Quaternion.Euler(0, 0, -lazerYonDerece-180);


    }


    private void OnTriggerEnter2D(Collider2D col)
    {


        if (col.gameObject.tag == "duvar" || col.gameObject.tag == "meteor" || col.gameObject.tag == "karakter" || col.gameObject.tag == "karadelik")
        {

            Destroy(gameObject);

        }




    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
