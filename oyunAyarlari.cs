using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class oyunAyarlari : MonoBehaviour
{

    public InputField ad;
    string adi;


    // Start is called before the first frame update
    void Start()
    {

        GameObject mainCamera = GameObject.Find("Main Camera");

        Camera.main.orthographicSize = (1080 * (9f / 16f) / 2) / 100;

        Camera.main.aspect = 16f / 9f;

        float camHalfHeight = Camera.main.orthographicSize;
        float camHalfWidth = Camera.main.aspect * camHalfHeight;

        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, camHalfHeight, mainCamera.transform.position.z);

        Vector3 topLeftPosition = new Vector3(-camHalfWidth, camHalfHeight, 0) + Camera.main.transform.position;
       


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void giris()
    {
        adi = ad.text;
        PlayerPrefs.SetString("ad", adi);
        SceneManager.LoadScene("zorluk");



    }
    public void skor()
    {

        PlayerPrefs.SetInt("yetkili", 0);
        PlayerPrefs.SetInt("skorDurum", 0);
        PlayerPrefs.SetInt("liste", 0);
        SceneManager.LoadScene("skor");



    }

    public void yetkili()
    {

        PlayerPrefs.SetInt("skorDurum", 0);
        PlayerPrefs.SetInt("liste", 0);
        SceneManager.LoadScene("yetkiligiris");



    }


}
