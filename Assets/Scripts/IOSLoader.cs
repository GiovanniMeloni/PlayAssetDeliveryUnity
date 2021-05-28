using UnityEngine;
using UnityEngine.iOS;
using System;
using System.Collections;

public class IOSLoader : MonoBehaviour
{
    public AssetBundle assetBundle;


    public void InvokeLoad()
    {
        StartCoroutine(LoadAsset("testbundle", "testbundle-tag"));
    }

    public IEnumerator LoadAsset(string resourceName, string odrTag)
    {
        // Create the request
        OnDemandResourcesRequest request = OnDemandResources.PreloadAsync(new string[] { odrTag });

        // Wait until request is completed
        yield return request;

        // Check for errors
        if (request.error != null)
            throw new Exception("ODR request failed: " + request.error);

        assetBundle = AssetBundle.LoadFromFile("res://" + resourceName);

        request.Dispose();
    }
}