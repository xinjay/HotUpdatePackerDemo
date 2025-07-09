using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;

public class ABTest : MonoBehaviour
{
    public Font font;

    public Shader shader;

    public GameObject prefab;

    public Material abMat;

    // Start is called before the first frame update
    void Start()
    {
        LoadAbRes();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LoadAbRes()
    {
#if UNITY_EDITOR
        var abname = "Assets/StreamingAssets/abres";
#else
         var abname = Path.Combine(Application.streamingAssetsPath,"abres");
#endif
        AssetBundle.UnloadAllAssetBundles(true);
        var ab = AssetBundle.LoadFromFile(abname);
        // var abTextName = "abtext";
        // var obj = ab.LoadAsset<Object>(abTextName);
        // prefab =obj  as GameObject;
        Debug.LogWarning("----------------LoadFromAssetBundle-------------------");
        var abMatName = "urptextureshader";
        shader = ab.LoadAsset<Shader>(abMatName);
    }

#if UNITY_EDITOR
    [MenuItem("xinjay/PackAB")]
    static void PackAB()
    {
        var objs = Selection.objects;
        var list = objs.Select(item => AssetDatabase.GetAssetPath(item)).ToArray();
        var buildList = new List<AssetBundleBuild>() { };
        var build = new AssetBundleBuild();
        build.assetBundleName = "abres";
        build.assetNames = list;
        buildList.Add(build);

        var outPath = "Assets/StreamingAssets";
        var target = BuildTarget.StandaloneWindows;

        BuildPipeline.BuildAssetBundles(outPath, buildList.ToArray(),
            BuildAssetBundleOptions.DisableLoadAssetByFileNameWithExtension |
            BuildAssetBundleOptions.ChunkBasedCompression |
            BuildAssetBundleOptions.StrictMode | BuildAssetBundleOptions.AssetBundleStripUnityVersion,
            target);
    }

    [MenuItem("Tools/Build AssetBundle Without B")]
    static void BuildBundleWithoutB()
    {
        string assetAPath = AssetDatabase.GetAssetPath(Selection.activeObject);
        var dependencies = AssetDatabase.GetDependencies(assetAPath, true);
        var filteredDependencies = dependencies.Where(path => !path.EndsWith("B.mat")).ToArray();

        AssetBundleBuild build = new AssetBundleBuild();
        build.assetBundleName = "assetA_bundle";
        build.assetNames = filteredDependencies;

        BuildPipeline.BuildAssetBundles("OutputPath", new[] { build }, BuildAssetBundleOptions.None,
            BuildTarget.StandaloneWindows);
    }

#endif
}