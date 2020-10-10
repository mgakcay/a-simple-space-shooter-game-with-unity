using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class oyunAyarlariZorluk : MonoBehaviour
{

    public Text yazi;
    // Start is called before the first frame update
    void Start()
    {
        yazi.text = "Hosgeldin  kaptan   " + PlayerPrefs.GetString("ad") + "   lutfen   bir   zorluk   seviyesi   sec";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void kolay()
    {
        PlayerPrefs.SetInt("zorluk", 10);
        SceneManager.LoadScene("oyun");



    }

    public void orta()
    {
        PlayerPrefs.SetInt("zorluk", 15);
        SceneManager.LoadScene("oyun");


    }

    public void zor()
    {
        PlayerPrefs.SetInt("zorluk", 20);
        SceneManager.LoadScene("oyun");



    }
}
