using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public Text yazi;
    public Text adliYazi;
    void Start()
    {
        PlayerPrefs.SetInt("skorDurum", 1);

        PlayerPrefs.SetInt("yetkili", 0);

        adliYazi.text = "Oyunu Kaybettin  " + PlayerPrefs.GetString("ad");
        yazi.text = "SKORUN:  " + PlayerPrefs.GetInt("skor");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void skorKaydet()
    {
        SceneManager.LoadScene("skor");


    }
    public void anaEkran()
    {

        PlayerPrefs.SetInt("skorDurum", 0);
        SceneManager.LoadScene("main");


    }
}
