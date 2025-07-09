using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblyDefineSample
{
    public static void Call<T>(string _msg)
    {
        var msg = $"From AssemblyDefineSample:{typeof(T).FullName}->{_msg}";
        Logger.AppendLog(msg);
    }
}