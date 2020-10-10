using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using Assets.Scripts;
using UnityEngine;
using System.IO;


public class ss : MonoBehaviour
{

    private static ss _instance;



    public static ss Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ss>();

                if (_instance == null)
                {

                    GameObject go = new GameObject();
                    go.name = typeof(ss).Name;
                    _instance = go.AddComponent<ss>();
                    DontDestroyOnLoad(go);

                }
            }


            return _instance;
        }
    }
    public IEnumerator Get(string url, System.Action<playerList> callBack)
    {

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);

                    jsonResult = jsonResult.Replace("[", "{\"players\": [");
                    jsonResult = jsonResult.Replace("]", "]}");


                    // jsonResult = "{ \"Scores\": [" + jsonResult;
                    //  jsonResult = jsonResult + "]}";


                    playerList pl = JsonUtility.FromJson<playerList>(jsonResult);
                    callBack(pl);





                }
            }
        }

    }


    public IEnumerator Delete(string url, int id)
    {

        string urlWithParams = string.Format("{0}{1}", url, id);

        using (UnityWebRequest www = UnityWebRequest.Delete(urlWithParams))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {

                    // jsonResult = "{ \"Scores\": [" + jsonResult;
                    //  jsonResult = jsonResult + "]}";






                }
            }
        }

    }


    public IEnumerator Post(string url, string ad, int skor)
    {

        url = url + ad + "/" + skor;
        string jsonData = "basarili";
        using (UnityWebRequest www = UnityWebRequest.Post(url, jsonData))
        {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();
            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);


                    //    jsonResult = jsonResult.Replace("[", "{\"players\": [");
                    //   jsonResult = jsonResult.Replace("]", "]}");


                    // jsonResult = "{ \"Scores\": [" + jsonResult;
                    //  jsonResult = jsonResult + "]}";







                }
            }
        }

    }
    public IEnumerator Put(string url, int id, string ad, int skor)
    {

        url = url + id + "/" + ad + "/" + skor;
        string jsonData = "basarili";
        using (UnityWebRequest www = UnityWebRequest.Put(url, jsonData))
        {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();
            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);


                    //    jsonResult = jsonResult.Replace("[", "{\"players\": [");
                    //   jsonResult = jsonResult.Replace("]", "]}");


                    // jsonResult = "{ \"Scores\": [" + jsonResult;
                    //  jsonResult = jsonResult + "]}";







                }
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
