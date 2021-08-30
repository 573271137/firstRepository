
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

public static class BuildTool
{
    [MenuItem("Tools/GameFrame/打包Android APK")]
    public static void BuildAndroid()
    {

        Debug.Log("Build Android APK");
        BuildTarget buildTarget = BuildTarget.Android;
        // 切换到 Android 平台
        EditorUserBuildSettings.SwitchActiveBuildTarget(buildTarget);
        // keystore 路径, G:\keystore\one.keystore
        //PlayerSettings.Android.keystoreName = Application.dataPath + "/NewStudios.keystore";
        //// one.keystore 密码
        //PlayerSettings.Android.keystorePass = "123456";

        //// one.keystore 别名
        //PlayerSettings.Android.keyaliasName = "newstudios";
        //// 别名密码
        //PlayerSettings.Android.keyaliasPass = "123456";

        List<string> levels = new List<string>();
        foreach(EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if(!scene.enabled) continue;
            // 获取有效的 Scene
            levels.Add(scene.path);
        }

        string time = DateTime.Now.ToString("yyyy-MM-dd/hh:mm:ss");
        string dir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        string apkName = string.Format(dir + "\\" + Application.productName + "{0}.apk", "");

        Debug.Log(apkName);

        // 执行打包
        BuildPipeline.BuildPlayer(levels.ToArray(), apkName, buildTarget, BuildOptions.None);

        AssetDatabase.Refresh();
    }
}






