using System;
using UnityEngine;
using UnityEditor;

public class CreateAssetBundles
{
    [MenuItem("Assets/Build AssetBundlesssss")]
    private static void BuildAddAssetBundles()
    {
        string assetBunleDirectoryPath = Application.dataPath + "/AssetBundles";

        BuildPipeline.BuildAssetBundles(assetBunleDirectoryPath, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);

        
    }
}
