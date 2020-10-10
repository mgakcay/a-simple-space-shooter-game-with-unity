using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class kraliceKontrol : MonoBehaviour
{

    public GameObject karaDelik;
    public GameObject meteor;
    
    GameObject karakter;

    int birSonrakiGidilecekYerNumarasi = 0;
    bool aradakiMesafeyiBirKereAl = true;
    bool ileri = true;
    float hiz = 20;
    float meteorDogurmaZamani;
    float karaDelikDogurmaZamani;
    Vector3 aradakiMesafe;


    GameObject[] gidilecekNotalar;

    void Start()
    {

        karakter = GameObject.FindGameObjectWithTag("karakter");
        gidilecekNotalar = new GameObject[transform.childCount];

        for (int i = 0; i < gidilecekNotalar.Length; i++)

        {
            gidilecekNotalar[i] = transform.GetChild(0).gameObject;
            gidilecekNotalar[i].transform.SetParent(transform.parent);
        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        NoktalaraGit();
        Dogur();



    }


    void Dogur()
    {

        meteorDogurmaZamani += Time.deltaTime;
        karaDelikDogurmaZamani += Time.deltaTime;

        if (meteorDogurmaZamani > Random.Range(2f, 5))
        {
            Instantiate(meteor, transform.position, Quaternion.identity, transform.parent);

            meteorDogurmaZamani = 0;


        }

        if (karaDelikDogurmaZamani > Random.Range(15f, 25))
        {
            Instantiate(karaDelik, transform.position, Quaternion.identity, transform.parent);

            karaDelikDogurmaZamani = 0;


        }

    }

    public Vector3 getYon()
    {
        return (karakter.transform.position - transform.position).normalized;


    }

    void NoktalaraGit()
    {

        if (aradakiMesafeyiBirKereAl)
        {
            aradakiMesafe = (gidilecekNotalar[birSonrakiGidilecekYerNumarasi].transform.position - transform.position).normalized;

            aradakiMesafeyiBirKereAl = false;

        }

        transform.position += aradakiMesafe * Time.deltaTime * hiz;


        if (birSonrakiGidilecekYerNumarasi >= gidilecekNotalar.Length - 1)
        {
            ileri = false;
        }
        else if (birSonrakiGidilecekYerNumarasi == 0)
        {
            ileri = true;
        }




        if (Vector3.Distance(transform.position, gidilecekNotalar[birSonrakiGidilecekYerNumarasi].transform.position) < 0.5f)
        {

            aradakiMesafeyiBirKereAl = true;

            if (ileri)
            {
                birSonrakiGidilecekYerNumarasi++;
            }
            else
            {
                birSonrakiGidilecekYerNumarasi--;
            }


        }


    }








#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.GetChild(i).transform.position, 0.7f);


        }

        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.GetChild(i).transform.position, transform.GetChild(i + 1).transform.position);



        }

    }

#endif





#if UNITY_EDITOR
    [CustomEditor(typeof(kraliceKontrol))]
    [System.Serializable]
    class kraliceKontrolEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            kraliceKontrol script = (kraliceKontrol)target;

            if (GUILayout.Button("uret"))
            {
                GameObject yeniObje = new GameObject();
                yeniObje.transform.parent = script.transform;
                yeniObje.transform.position = script.transform.position;
                yeniObje.name = script.transform.childCount.ToString();



            }
            EditorGUILayout.PropertyField(serializedObject.FindProperty("karaDelik"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("meteor"));
            serializedObject.ApplyModifiedProperties();
            serializedObject.Update();

        }

    }


#endif




}
