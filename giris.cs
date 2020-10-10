using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class giris : MonoBehaviour
{

    public InputField k_ad;
    public InputField k_sifre;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void girisKontrol()
    {
        string kullaniciAdi = k_ad.text;
        string kullaniciSifre = k_sifre.text;

        if (kullaniciAdi.Equals("Gorkem") && kullaniciSifre.Equals("123456789"))
        {
        
                SceneManager.LoadScene("yetkili");
            PlayerPrefs.SetInt("yetkili", 1);

        
        }
        else
        {
        }
        
    }

    public void anaMenu()
    {

        SceneManager.LoadScene("main");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
