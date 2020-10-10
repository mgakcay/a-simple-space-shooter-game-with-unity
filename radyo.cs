using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class radyo : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    AudioSource audioSource;
    public Text yazi;

    void Start()
    {
        audioSource = cam.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void radyoKapat()
    {
        if (audioSource.mute)
        {
            audioSource.mute = false;
            yazi.text = "uzay radyosu kapat";
        }
        else
        {

            audioSource.mute = true;
            yazi.text = "uzay radyosu ac";
        }
    }
}
