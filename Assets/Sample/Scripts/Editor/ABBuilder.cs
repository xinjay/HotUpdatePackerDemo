using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;

public class ABBuilder
{
    [MenuItem("Tools/PackAB")]
    static void PackAB()
    {
        var res = "Assets/Sample/Res";
        var resArr = AssetDatabase.GetAllAssetPaths().Where(item => item.Contains(res)).ToArray();
        var buildList = new List<AssetBundleBuild>() { };
        var build = new AssetBundleBuild();
        build.assetBundleName = "abres.ab";
        build.assetNames = resArr;
        buildList.Add(build);
        var outPath = "Assets/StreamingAssets";
        var target = EditorUserBuildSettings.activeBuildTarget;
        BuildPipeline.BuildAssetBundles(outPath, buildList.ToArray(),
            BuildAssetBundleOptions.DisableLoadAssetByFileNameWithExtension |
            BuildAssetBundleOptions.ChunkBasedCompression |
            BuildAssetBundleOptions.StrictMode | BuildAssetBundleOptions.AssetBundleStripUnityVersion,
            target);
    }
}