using UnityEngine;

public class Logger : MonoBehaviour
{
    private static string message = "LoggerStart";

    public static void AppendLog(string message)
    {
        Logger.message += $"\nLogger->{message}";
    }

    void OnGUI()
    {
        GUILayout.Label(message);
    }
}