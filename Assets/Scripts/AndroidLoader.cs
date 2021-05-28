//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Google.Play.AssetDelivery;

//public class AndroidLoader : MonoBehaviour
//{
//    public string assetName = "Cube";
//    public string bundleName = "testbundle";

//    public GameObject DebugGameObject;

//    public void Load()
//    {
//        PlayAssetBundleRequest bundleRequest = PlayAssetDelivery.RetrieveAssetBundleAsync(bundleName);

//        AssetBundle assetBundle = bundleRequest.AssetBundle;

//        if (assetBundle == null)
//        {
//            Debug.LogError("Failed to load");
//            DebugGameObject.SetActive(true);
//            return;
//        }

//        GameObject asset = assetBundle.LoadAsset<GameObject>(assetName);
//        Instantiate(asset);
//        assetBundle.Unload(false);
//    }

//    public void InvokeAndroidAsyncLoader()
//    {
//        StartCoroutine(AsyncLoader());
//    }

//    public IEnumerator AsyncLoader()
//    {

//        PlayAssetBundleRequest bundleRequest = PlayAssetDelivery.RetrieveAssetBundleAsync(bundleName);
//        yield return bundleRequest;

        
//        AssetBundle assetBundle = bundleRequest.AssetBundle;

//        if (assetBundle == null)
//        {
//            Debug.LogError("Failed to load");
//            yield break;
//        }

//        AssetBundleRequest assetRequest = assetBundle.LoadAssetAsync<GameObject>(assetName);
//        yield return assetRequest;

//        GameObject asset = assetRequest.asset as GameObject;
//        Instantiate(asset);

//        assetBundle.Unload(false);

//    }
//}
