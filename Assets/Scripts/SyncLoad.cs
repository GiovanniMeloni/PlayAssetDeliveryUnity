using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SyncLoad : MonoBehaviour
{
    public string assetName = "Cube";
    public string bundleName = "testbundle";

    public void Load()
    {
        AssetBundle assetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, bundleName));

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
