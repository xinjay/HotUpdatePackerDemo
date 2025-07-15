using System;
using HotUpdatePacker.Runtime;
using UnityEngine;
using System.IO;
using Object = UnityEngine.Object;

namespace HotUpdatePacker
{
    public class SimpleAssetsLoader : IAssetsLoader
    {
        private static SimpleAssetsLoader _instance;

        public static SimpleAssetsLoader Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SimpleAssetsLoader();
                    _instance.LoadAbRes();
                }

                return _instance;
            }
        }

        private AssetBundle bundle;

        public void LoadAbRes()
        {
#if UNITY_EDITOR
            var abname = "Assets/StreamingAssets/abres.ab";
#else
            var abname = Path.Combine(Application.streamingAssetsPath, "abres.ab");
#endif
            AssetBundle.UnloadAllAssetBundles(true);
            bundle = AssetBundle.LoadFromFile(abname);
        }


        public void LoadAsset<T>(string fileName, Action<T> callback, bool unload) where T : Object
        {
            var asset = bundle.LoadAsset<T>(fileName);
            callback.Invoke(asset);
        }

        public void LoadBytes(string fileName, Action<byte[]> callback)
        {
            var asset = bundle.LoadAsset<TextAsset>(fileName);
            var bytes = asset.bytes;
            callback.Invoke(bytes);
        }

        public void LoadText(string fileName, Action<string> callback)
        {
            var asset = bundle.LoadAsset<TextAsset>(fileName);
            var text = asset.text;
            callback.Invoke(text);
        }
    }
}