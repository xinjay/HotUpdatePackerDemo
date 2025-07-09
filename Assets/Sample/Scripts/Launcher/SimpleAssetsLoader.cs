using System;
using HotUpdatePacker.Runtime;

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
                    _instance = new SimpleAssetsLoader();
                return _instance;
            }
        }

        public void LoadAsset<T>(string fileName, Action<T> callback, bool unload) where T : class
        {
            //AssetUtils.SyncLoad_File(fileName, (obj) => { callback.Invoke(obj as T); }, unload);
        }

        public void LoadBytes(string fileName, Action<byte[]> callback)
        {
            //var bytes = AssetUtils.GetAllBytesByIO(fileName);
            // callback.Invoke(bytes);
        }

        public void LoadText(string fileName, Action<string> callback)
        {
            //var text = AssetUtils.GetAllTextByIO(fileName);
            //callback.Invoke(text);
        }
    }
}