using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Networking;
using System;

public class SyncLoad : MonoBehaviour
{
    public string assetName = "Cube";
    public string bundleName = "testbundle";

    public void Load()
    {
        string path = Path.Combine(Application.streamingAssetsPath, bundleName);

        AssetBundle assetBundle = AssetBundle.LoadFromFile(path);


        if (assetBundle == null)
        {
            Debug.LogError("Failed to load");
            return;
        }

        GameObject asset = assetBundle.LoadAsset<GameObject>(assetName);
        Instantiate(asset);
        assetBundle.Unload(false);
    }
}
