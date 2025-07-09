using System;
using UnityEngine;
using System.IO;
using System.Reflection;
using HotUpdatePacker;
using HotUpdatePacker.Runtime;
using HybridCLR;

public class Launcher : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        //HoteUpdateAssemblyLoader.Init(SimpleAssetsLoader.Instance);
        HotUpdateAOT.ReflectCallMethod(RefelectDefines.KlassName, RefelectDefines.MethodName,
            BindingFlags.Public | BindingFlags.Static, null);
        HotUpdateAOT.ReflectCallMethod(RefelectDefines.KlassName2, RefelectDefines.MethodName,
            BindingFlags.Public | BindingFlags.Static, null);
    }
}