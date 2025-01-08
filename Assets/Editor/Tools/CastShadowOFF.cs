using UnityEditor;
using UnityEngine;

public class CastShadowOFF : MonoBehaviour
{
    [MenuItem("Tools/Disable Shadows for Selected Object")]
    static void DisableShadows()
    {
        // Проверяем, что выделен хотя бы один объект
        if (Selection.activeGameObject == null)
        {
            Debug.LogError("No object selected. Please select an object to disable shadows.");
            return;
        }

        GameObject selectedObject = Selection.activeGameObject;

        // Получаем все компоненты MeshRenderer, включая отключенных детей
        MeshRenderer[] renderers = selectedObject.GetComponentsInChildren<MeshRenderer>(true);

        if (renderers.Length == 0)
        {
            Debug.LogWarning("No MeshRenderer found on the selected object or its children.");
            return;
        }

        // Перебираем все MeshRenderer и отключаем cast shadows
        foreach (MeshRenderer renderer in renderers)
        {
            renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        }

        Debug.Log($"Shadows disabled for {renderers.Length} renderers in '{selectedObject.name}' and its children.");
    }
}
