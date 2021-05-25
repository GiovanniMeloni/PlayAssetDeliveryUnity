using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AsyncLoader : MonoBehaviour
{
    public string assetName = "Cube";
    public string bundleName = "testbundle";

    public void InvokeLoaderAsync()
    {
        StartCoroutine(Load());
    }

    public IEnumerator Load()
    {
        AssetBundleCreateRequest asyncBundleRequest = AssetBundle.LoadFromFileAsync(Path.Combine(Application.streamingAssetsPath, bundleName));
        yield return asyncBundleRequest;

        AssetBundle assetBundle = asyncBundleRequest.assetBundle;

        if (assetBundle == null)
        {
            Debug.LogError("Failed to load");
            yield break;
        }

        AssetBundleRequest assetRequest = assetBundle.LoadAssetAsync<GameObject>(assetName);
        yield return assetRequest;

        GameObject asset = assetRequest.asset as GameObject;
        Instantiate(asset);

        assetBundle.Unload(false);
    }
}
