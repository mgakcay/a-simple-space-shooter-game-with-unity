using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class GAME : MonoBehaviour
{
    int[] skor_id = new int[99];
    string[] skor_adi = new string[99];
    int[] skor = new int[99];
    public string WEB_URL = "";
    public string WEB_URL_DELETE = "";
    public string WEB_URL_PUT = "";
    int yetkili = 1;

    public string WEB_URL_POST = "";
    public int i = 0;
    public Text skorListesi;
    public InputField silinecekID;
    public InputField degisecekID;
    public InputField skoradi;
    public InputField skoru;

    void Start()
    {

        //   
        if (PlayerPrefs.GetInt("skorDurum") == 1)
        {
            StartCoroutine(ss.Instance.Post(WEB_URL_POST, PlayerPrefs.GetString("ad"), PlayerPrefs.GetInt("skor")));

            StartCoroutine(ss.Instance.Delete(WEB_URL_DELETE, 9));
        }

        StartCoroutine(ss.Instance.Delete(WEB_URL_DELETE, 9));
        StartCoroutine(ss.Instance.Delete(WEB_URL_DELETE, 9));
        StartCoroutine(ss.Instance.Delete(WEB_URL_DELETE, 9));


        StartCoroutine(ss.Instance.Get(WEB_URL, GetPlayers));

    }

    void GetPlayers(playerList pl)
    {

        yetkili = PlayerPrefs.GetInt("yetkili");
        if (yetkili == 1)
        {
            int i = 0;
            foreach (player player in pl.players)
            {

                skorListesi.text = skorListesi.text + "\n" + (i + 1) + ".    " + "id: " + player.skor_id + "      " +  player.skor_adi + " ---> " + player.skor;
                skor_id[i] = player.skor_id;
                skor_adi[i] = player.skor_adi;
                skor[i] = player.skor;
                i++;

            }


        }
        else
        {
            int i = 0;
            foreach (player player in pl.players)
            {

                skorListesi.text = skorListesi.text + "\n" + (i + 1) + ".    " + player.skor_adi + " ---> " + player.skor;
                skor_id[i] = player.skor_id;
                skor_adi[i] = player.skor_adi;
                skor[i] = player.skor;
                i++;

            }

        }


    }
    // Update is called once per frame

    public void silme()
    {

        string a = silinecekID.text;
        int b = int.Parse(a);

        StartCoroutine(ss.Instance.Delete(WEB_URL_DELETE, b));




    }
    public void degistirme()
    {

        string a = degisecekID.text;
        int b = int.Parse(a);

        string c = skoradi.text;

        string d = skoru.text;
        int e = int.Parse(d);


        StartCoroutine(ss.Instance.Put(WEB_URL_PUT, b, c, e));



    }


    public void ekranYenile()
    {


        skorListesi.text = "Skor Listesi";
        StartCoroutine(ss.Instance.Get(WEB_URL, GetPlayers));
      


    }
   

    public void anaEkran()
    {


        SceneManager.LoadScene("main");

    }
}

