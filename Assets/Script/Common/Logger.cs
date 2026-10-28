using System.Diagnostics;
using UnityEngine;

public static class Logger
{
    public static void Log(object message)
    {
        UnityEngine.Debug.Log(message);
    }
}
