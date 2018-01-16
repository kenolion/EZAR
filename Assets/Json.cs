using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LitJson;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class Json : MonoBehaviour
{
    public List<String> parsejson;


    // Sample JSON for the following script has attached.
    public IEnumerator initialize(float lat, float lon, int radius)
    {
        //klcc = 3.1577405 101.712167
        //kl tower = 3.152917 101.7038288
        string url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" + 3.152917 + "," + 101.7038288 + "&radius=" + radius + "&type=point_of_interest&key=AIzaSyAQuGtZ-z9MwBefxyW5hAY25-O50XKj_J0";

        WWW www = new WWW(url);
        yield return www;
        if (www.error == null)
        {
            Processjson(www.text);
        }
        else
        {
            Debug.Log("ERROR: " + www.error);
        }
    }
    private void Processjson(string jsonString)
    {
        JsonData jsonvale = JsonMapper.ToObject(jsonString);
       
        parsejson = new List<String>();

        //parsejson.places = new ArrayList();

        for (int i = 0; i < jsonvale["results"].Count; i++)
        {

            parsejson.Add((string)jsonvale["results"][i]["name"]);

            Debug.Log(parsejson[i]);

        }
        GetComponent<Manager>().panels[1].transform.GetChild(3).GetComponent<Dropdown>().ClearOptions();
        GetComponent<Manager>().panels[1].transform.GetChild(3).GetComponent<Dropdown>().AddOptions(GetComponent<LocationService>().json.parsejson);
    }

}
public class parseJSON
{
    public string name;
    

    private GameObject model;

    public parseJSON(string name)
    {
        this.name = name;
    }

    public override string ToString()
    {
        return name;
    }
}
