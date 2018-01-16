using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Storage;
using UnityEngine;
using UnityEngine.UI;

public class DownloadAsset : MonoBehaviour
{
    private string url;
    public GameObject parentOfMarker;
    public GameObject downloadedDialog;
    public GameObject model;
    private Firebase.Storage.StorageReference storage_ref;
    public void Start()
    {
        Firebase.Storage.FirebaseStorage storage = Firebase.Storage.FirebaseStorage.DefaultInstance;
        storage_ref =
            storage.GetReferenceFromUrl("gs://arassignment-191811.appspot.com");
    }

    public void Download(String name)
    {
        string urlname = WWW.EscapeURL(name);
        
        url = "https://firebasestorage.googleapis.com/v0/b/arassignment-191811.appspot.com/o/" + urlname.ToLower() + "?alt=media";
        WWW www = new WWW(url);
        StartCoroutine(WaitForReq(www,name));
        
    }


    IEnumerator WaitForReq(WWW www,string name)
    {
        yield return www;
        AssetBundle bundle = www.assetBundle;
        StopAllCoroutines();
        downloadedDialog.GetComponent<CanvasGroup>().alpha = 1;
        if (www.error == null)
        {
            GameObject tempGameObject = (GameObject) bundle.LoadAsset(name.ToLower());
            model = Instantiate(tempGameObject);
            downloadedDialog.transform.GetChild(0).GetComponent<Text>().text = name + "Downloaded";
        }
        else
        {
            downloadedDialog.transform.GetChild(0).GetComponent<Text>().text ="Download link not found Error";
            Debug.Log(www.error);
        }
        StartCoroutine(FadeOutQualityDialog());
    }


    IEnumerator FadeOutQualityDialog() //feedback
    {
        yield return new WaitForSeconds(1f);
        CanvasGroup canvasGroup = downloadedDialog.GetComponent<CanvasGroup>();

        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            f = (float)Math.Round(f, 1);
            Debug.Log("FadeOut: " + f);
            canvasGroup.alpha = (float)Math.Round(f, 1);
            yield return null;
        }
    }



}
