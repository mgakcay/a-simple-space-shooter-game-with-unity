using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class karakterKontrol : MonoBehaviour
{

    public AudioClip sesMeteorKlip;
    public AudioSource sesMeteor;
    public AudioClip sesCoinKlip;
    public AudioSource sesCoin; 
    public AudioClip sesKalkanKlip;
    public AudioSource sesKalkan;
    public AudioClip sesCanKlip;
    public AudioSource sesCan;

    Rigidbody2D fizik;
    public AudioClip sesKlip;
    public AudioSource ses;
    public Text ruzgarXText;
    public Text ruzgarYText;
    public Text canText; 
    public Text skorText;
    public Image ruzgarYonImage;
    public Button barBeyaz;
    public GameObject coin;
    public GameObject can;
    public GameObject kalkan;

    Vector3 hareketVector;
    float ikiCarpmaArasiSayac =0;
    float karakterHiz = 7;
    int ruzgarHiz = 150;
    float ruzgarSertlik;
    int karakterCan = 1000;
    int karakterSkor = 0;
    bool kalkanDurumu = false;

    float MinX = -4.5f;
    float MaxX = 4.5f;
    float MinY = 1;
    float MaxY = -9;

    float Horizontal = 0;
    float Vertical = 0;
    float ruzgarX, ruzgarY = 0;

    float coinSpawnTimer = 5f;
    float canSpawnTimer = 20f;
    float kalkanSpawnTimer = 17f;


    float ruzgarSayaci;
    GameObject canKazanama; 
    GameObject coinKazanama;
    GameObject kalkanKazanama; 
    GameObject aktifCan;
    GameObject aktifCoin;
    GameObject aktifKalkan;
    GameObject karakter;

    int zorluk;
    int zorlukDerece;

    void Start()
    {







        zorluk = PlayerPrefs.GetInt("zorluk"); 
        zorlukDerece = zorluk;
        karakterHiz = 7 * ((zorlukDerece - 10) / 5 + 1);


        fizik = GetComponent<Rigidbody2D>();
        karakter = GameObject.FindWithTag("karakter");
    }


    void Update()
    {
       
    }


    void coinSpawn()
    {
        aktifCoin = GameObject.FindWithTag("coin");
        Destroy(aktifCoin);
        float x = Random.Range(MinX, MaxX);
        float y = Random.Range(MinY, MaxY);


        Instantiate(coin, new Vector3(x, y, 0), Quaternion.identity);

    }
    void canSpawn()
    {
        aktifCan = GameObject.FindWithTag("can");
        Destroy(aktifCan);
        float x = Random.Range(MinX, MaxX);
        float y = Random.Range(MinY, MaxY);


        Instantiate(can, new Vector3(x, y, 0), Quaternion.identity);

    }
    void kalkanSpawn()
    {
        aktifKalkan= GameObject.FindWithTag("kalkan");
        Destroy(aktifKalkan);

        float x = Random.Range(MinX, MaxX);
        float y = Random.Range(MinY, MaxY);


        Instantiate(kalkan, new Vector3(x, y, 0), Quaternion.identity);

    }

    void FixedUpdate()
    {
        if (karakterCan <= 0)
        {

            PlayerPrefs.SetInt("skor", karakterSkor);
            SceneManager.LoadScene("gameover");

        }
        coinSpawnTimer -= Time.deltaTime;
        if (coinSpawnTimer <= 0f)
        {
            coinSpawn();

            coinSpawnTimer = 5f;
        }

        canSpawnTimer -= Time.deltaTime;
        if (canSpawnTimer <= 0f)
        {
            canSpawn();

            canSpawnTimer = 20f;
        }


        kalkanSpawnTimer -= Time.deltaTime;
        if (kalkanSpawnTimer <= 0f)
        {
            kalkanSpawn();

            kalkanSpawnTimer  = 17f;
        }





        karakterSkor += 1*((zorlukDerece-10)/5 + 1);
        skorText.text = "Skor:" + karakterSkor;
        KarakterHareket();
        Ruzgar();
        ikiCarpmaArasiSayac += Time.deltaTime;


        if (karakter.transform.childCount > 0)
        {
            kalkanDurumu = true;
        }
        else
        {
            kalkanDurumu = false;

        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (!kalkanDurumu) { 
        if (ikiCarpmaArasiSayac > 1)
        {
            if (col.gameObject.tag == "dusman")
            {

                    sesMeteor.PlayOneShot(sesMeteorKlip);
                    karakterCan -= 100;
                canText.text = "Can:" + karakterCan;
                ikiCarpmaArasiSayac = 0;
            }

            if (col.gameObject.tag == "meteor")
            {
                    sesMeteor.PlayOneShot(sesMeteorKlip);
                    karakterCan -= 100;
                canText.text = "Can:" + karakterCan;
                ikiCarpmaArasiSayac = 0;
            }
        }

        }


    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "can")
        {

            sesCan.PlayOneShot(sesCanKlip);
            canKazanama = GameObject.FindWithTag("can");
            karakterCan += 500;
            canText.text = "Can:" + karakterCan;
            //    karakter = GameObject.FindWithTag("karakter");
            //    canKazanama.transform.SetParent(karakter.transform);



            Destroy(canKazanama);


        }

        if (col.gameObject.tag == "coin")
        {

            sesCoin.PlayOneShot(sesCoinKlip);
            coinKazanama = GameObject.FindWithTag("coin");
            karakterSkor += 1000;
            skorText.text = "Skor:" + karakterSkor;
            //    karakter = GameObject.FindWithTag("karakter");
            //    canKazanama.transform.SetParent(karakter.transform);



            Destroy(coinKazanama);


        }


        if (col.gameObject.tag == "kalkan")
        {

            sesKalkan.PlayOneShot(sesKalkanKlip);
            kalkanKazanama = GameObject.FindWithTag("kalkan");
            kalkanKazanama.tag = "aktifKalkan";
            kalkanKazanama.transform.SetParent(karakter.transform);
           kalkanKazanama.transform.localPosition = new Vector3(0, 0, 0);
            Destroy(kalkanKazanama, 5.0f);





        }




        if (!kalkanDurumu) { 

            if (col.gameObject.tag == "lazer")
        {
                ses.PlayOneShot(sesKlip);
            karakterCan -= 10;
            canText.text = "Can:" + karakterCan;
        }

        if (col.gameObject.tag == "karadelik")
        {

            karakterCan -= 50000;
            canText.text = "Can:" + karakterCan;
        }

        }
    }

    void KarakterHareket()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        hareketVector = new Vector3(Horizontal * karakterHiz, Vertical * karakterHiz, 0);
        fizik.velocity = hareketVector;

    }

    void Ruzgar()
    {
        ruzgarSayaci += Time.deltaTime;

        if (ruzgarSayaci > 2)
        {

             ruzgarX = Random.Range(-(ruzgarHiz * ((zorlukDerece - 10) / 5 + 1)), +(ruzgarHiz * ((zorlukDerece - 10) / 5 + 1)));
             ruzgarY = Random.Range(-(ruzgarHiz * ((zorlukDerece - 10) / 5 + 1)), +(ruzgarHiz * ((zorlukDerece - 10) / 5 + 1)));




            float ruzgarYonDerece = Vector3.Angle(new Vector3(0.0f, 1.0f, 0.0f), new Vector3(ruzgarY, ruzgarX, 0.0f));


            if (ruzgarY < 0.0f)
            {
                ruzgarYonDerece = -ruzgarYonDerece;
                ruzgarYonDerece = ruzgarYonDerece + 360;
            }

            ruzgarYonImage.transform.rotation = Quaternion.Euler(0, 0, ruzgarYonDerece);
            ruzgarXText.text = "X: " + (int)ruzgarX ;
            ruzgarYText.text = "Y: " + (int)ruzgarY ;

            ruzgarSertlik = Vector3.Magnitude(new Vector3(ruzgarX, ruzgarY, 0));

            ruzgarSertlik = ruzgarSertlik / Vector3.Magnitude(new Vector3((ruzgarHiz * ((zorlukDerece - 10) / 5 + 1)), (ruzgarHiz * ((zorlukDerece - 10) / 5 + 1)), 0));

            barBeyaz.transform.localScale = new Vector3(ruzgarSertlik, 1, 1);


            ruzgarSayaci = 0;
        }


        fizik.AddForce(new Vector2(ruzgarX,ruzgarY));


    }



}
