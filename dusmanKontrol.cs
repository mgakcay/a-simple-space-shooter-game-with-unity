using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class dusmanKontrol : MonoBehaviour
{
    float atesZamani;
    public GameObject kursun;
    public GameObject karakter;
    public oyunAyarlari oyunAyarlari;

    int birSonrakiGidilecekYerNumarasi = 0;
    bool aradakiMesafeyiBirKereAl = true;
    bool ileri = true;
    float hiz = 3;
    Vector3 aradakiMesafe;


    GameObject[] gidilecekNotalar;


    void Start()
    {


        gidilecekNotalar = new GameObject[transform.childCount];

        for (int i = 0; i < gidilecekNotalar.Length; i++)

        {
            gidilecekNotalar[i] = transform.GetChild(0).gameObject;
            gidilecekNotalar[i].transform.SetParent(transform.parent);
        }

    }


    void FixedUpdate()
    {
        AtesEt();
        NoktalaraGit();
    }

    void AtesEt()
    {
        atesZamani += Time.deltaTime;

        if (atesZamani > Random.Range(0.2f, 1))
        {
            Instantiate(kursun, transform.position, Quaternion.identity, transform);

            atesZamani = 0;


        }


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

    public Vector3 getYon()
    {
        return (karakter.transform.position - transform.position).normalized;


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
    [CustomEditor(typeof(dusmanKontrol))]
    [System.Serializable]
    class dusmanKontrolEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            dusmanKontrol script = (dusmanKontrol)target;

            if (GUILayout.Button("uret"))
            {
                GameObject yeniObje = new GameObject();
                yeniObje.transform.parent = script.transform;
                yeniObje.transform.position = script.transform.position;
                yeniObje.name = script.transform.childCount.ToString();



            }

            EditorGUILayout.PropertyField(serializedObject.FindProperty("kursun"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("karakter"));
            serializedObject.ApplyModifiedProperties();
            serializedObject.Update();

        }

    }


#endif



}
