using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class EnterOppoMarket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        string time = DateTime.Now.ToString("yyyy-MM-dd/hh:mm:ss");
        string dir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        string apkName = string.Format(dir + "\\" + Application.productName + "{0}.apk", "");

        Debug.Log(apkName);
        return;

        string marketPkg = "com.xiaomi.market";
        string appPkg = "com.newstudios.fallinlove";

        Debug.Log($"???? {marketPkg} ????{appPkg}");

        AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
        AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
        intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_VIEW"));
        AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
        AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "market://details?id=" + appPkg);
        intentObject.Call<AndroidJavaObject>("setData", uriObject);
        intentObject.Call<AndroidJavaObject>("setPackage", marketPkg);
        AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
        currentActivity.Call("startActivity", intentObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
