﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationService : MonoBehaviour
{
    public Json json;
    IEnumerator Start()
    {
        // First, check if user has location service enabled
#if UNITY_EDITOR
        yield return new WaitWhile(() => !UnityEditor.EditorApplication.isRemoteConnected);
#endif

        Debug.Log("y u no start");
        if (!Input.location.isEnabledByUser)
            yield break;

        // Start service before querying location

        Input.location.Start(1, 1);

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " +
                  Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " +
                  Input.location.lastData.timestamp);
        }
        // Stop service if there is no need to query location updates continuously
       
        Input.location.Stop();
    }
    public void GetLocation()
    {
        json = GetComponent<Json>();

        StartCoroutine(Start());
        StartCoroutine(json.initialize(Input.location.lastData.latitude, Input.location.lastData.longitude, 500));
        
    }

}

