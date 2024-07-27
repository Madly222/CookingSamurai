using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTexturing : MonoBehaviour
{
    public Vector2 uvOffset = new Vector2(0.1f, 0.1f);

    // Масштабирование UV по оси X и Y
    public Vector2 uvScale = new Vector2(1.0f, 1.0f);

    void Start()
    {
        // Получаем компонент SkinnedMeshRenderer объекта
        SkinnedMeshRenderer skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();

        // Проверяем, что компонент SkinnedMeshRenderer найден
        if (skinnedMeshRenderer != null)
        {
            // Создаём копию меша, чтобы изменить UV координаты только для данного экземпляра объекта
            Mesh mesh = Instantiate(skinnedMeshRenderer.sharedMesh);
            skinnedMeshRenderer.sharedMesh = mesh;

            // Получаем текущие UV-координаты
            Vector2[] uvs = mesh.uv;

            // Применяем смещение и масштабирование UV
            for (int i = 0; i < uvs.Length; i++)
            {
                uvs[i] = Vector2.Scale(uvs[i], uvScale) + uvOffset;
            }

            // Применяем изменённые UV-координаты обратно к мешу
            mesh.uv = uvs;
        }
        else
        {
            Debug.LogError("Component SkinnedMeshRenderer not found on the GameObject.");
        }
    }
}
