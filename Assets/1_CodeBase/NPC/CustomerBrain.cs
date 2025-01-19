using System.Collections;
using UnityEngine;

public class CustomerBrain : MonoBehaviour
{
    [SerializeField] private Animator npcAnimator; // Ссылка на Animator

    [SerializeField] public Transform stopPoint; // Точка назначения
    
    public float rotationSpeed = 2f; // Скорость поворота
    public float stopDistance = 0.1f; // Минимальная дистанция до точки

    private static readonly int Wait = Animator.StringToHash("Wait");

    private void OnEnable()
    {
        if (stopPoint == null)
            return;
        
        StartCoroutine(MoveToPoint()); // Запускаем новую корутину
    }
    
    private IEnumerator MoveToPoint()
    {
        while (true)
        {
            float distance = Vector3.Distance(transform.position, stopPoint.position);

            // Если расстояние меньше или равно stopDistance
            if (distance <= stopDistance)
            {
                npcAnimator.SetBool(Wait, true); // Включаем анимацию ожидания
                yield return StartCoroutine(SmoothRotateToStopPoint()); // Выполняем плавный поворот
                yield break; // Завершаем корутину
            }

            // Поворот в сторону точки
            RotateTowardsTarget();

            yield return null; // Ждем до следующего кадра
        }
    }

    private void RotateTowardsTarget()
    {
        Vector3 direction = (stopPoint.position - transform.position).normalized;

        if (direction.sqrMagnitude > 0.001f) // Проверяем, чтобы направление было значимым
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private IEnumerator SmoothRotateToStopPoint()
    {
        Quaternion targetRotation = stopPoint.rotation; // Поворот к ориентации stopPoint

        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * 50f * Time.deltaTime);
            yield return null;
        }

        // Устанавливаем точный поворот
        transform.rotation = targetRotation;
    }

    private void AlignWithStopPoint()
    {
        // Поворот NPC в точную ориентацию stopPoint
        transform.rotation = stopPoint.rotation;
    }
}
