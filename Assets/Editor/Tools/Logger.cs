using UnityEngine;

public static class Logger
{
    public static void Log(string message, GameObject context = null)
    {
#if UNITY_EDITOR
        if (context != null)
            Debug.Log(message, context);
        else
            Debug.Log(message);
#endif
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    public static void LogWarning(string message, GameObject context = null)
    {
#if UNITY_EDITOR
        if (context != null)
            Debug.LogWarning(message, context);
        else
            Debug.LogWarning(message);
#endif
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    public static void LogError(string message, GameObject context = null)
    {
#if UNITY_EDITOR
        if (context != null)
            Debug.LogError(message, context);
        else
            Debug.LogError(message);
#endif
    }
}
