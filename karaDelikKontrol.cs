using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karaDelikKontrol : MonoBehaviour
{
    float karaDelikSayac;
    kraliceKontrol kralice;
    Rigidbody2D fizik;

    void Start()
    {
        kralice = GameObject.FindGameObjectWithTag("kralice").GetComponent<kraliceKontrol>();
        fizik = GetComponent<Rigidbody2D>();
        fizik.AddForce(kralice.getYon() * 100);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        KaraDelikHareket();
    }

    void KaraDelikHareket()
    {
        karaDelikSayac += Time.deltaTime;

        if (karaDelikSayac < 1)
        {
            transform.localScale += new Vector3(0.003f, 0.003f, 0);
        }
        else if (karaDelikSayac > 1)
        {
            transform.localScale += new Vector3(-0.003f, -0.003f, 0);
        }

        if (karaDelikSayac > 2)
        {

            karaDelikSayac = 0;
        }


        transform.Rotate(0, 0, 1.4f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {


        if (col.gameObject.tag == "duvar")
        {

            Destroy(gameObject);

        }




    }

}
