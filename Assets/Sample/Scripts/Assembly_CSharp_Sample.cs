using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assembly_CSharp_Sample
{
    public static void Call<T>(string _msg)
    {
        var msg = $"From Assembly_CSharp_Sample:{typeof(T).FullName}->{_msg}";
        Logger.AppendLog(msg);
    }
}