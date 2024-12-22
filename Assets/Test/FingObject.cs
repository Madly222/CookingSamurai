using System.Diagnostics;
using UnityEngine;

public class FingObject : MonoBehaviour
{
    private void OnDisable()
    {
        UnityEngine.Debug.Log($"Object {gameObject.name} was disabled.", this);
        
        // Получаем стек вызовов
        StackTrace stackTrace = new StackTrace();
        string trace = stackTrace.ToString();

        // Логируем стек вызовов
        UnityEngine.Debug.Log($"StackTrace for disabling {gameObject.name}:\n{trace}");
    }
}
