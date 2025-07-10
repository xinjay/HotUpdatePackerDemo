using System;
using UnityEngine;
using System.IO;
using System.Reflection;
using HotUpdatePacker;
using HotUpdatePacker.Runtime;
using HybridCLR;

public class Launcher : MonoBehaviour
{
    public bool useHotupdatDll;
    // Start is called before the first frame update

    void Start()
    {
#if UNITY_EDITOR
        if (useHotupdatDll)
            HoteUpdateAssemblyLoader.Init(SimpleAssetsLoader.Instance);
#else
        HoteUpdateAssemblyLoader.Init(SimpleAssetsLoader.Instance);
#endif
        HotUpdateAOT.ReflectCallMethod(RefelectDefines.KlassName, RefelectDefines.MethodName,
            BindingFlags.Public | BindingFlags.Static, null);
        HotUpdateAOT.ReflectCallMethod(RefelectDefines.KlassName2, RefelectDefines.MethodName,
            BindingFlags.Public | BindingFlags.Static, null);
    }
}