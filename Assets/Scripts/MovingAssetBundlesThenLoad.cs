using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Networking;
using System;

public class MovingAssetBundlesThenLoad : MonoBehaviour
{
    public string assetName = "Cube";
    public string bundleName = "testbundle";

    public void Load()
    {
        string pathCopyFrom = Path.Combine(Application.streamingAssetsPath, bundleName);
        string pathCopyTo = Path.Combine(Application.persistentDataPath, "AssetBundles", bundleName + ".unity3d");

        File.Copy(pathCopyFrom, pathCopyTo);

        AssetBundle assetBundle = AssetBundle.LoadFromFile(pathCopyTo);

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
