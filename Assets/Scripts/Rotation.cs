using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private GameObject target;

    void Update()
    {
        if (target == null) return;

        // Вектор до цели (с учётом высоты)
        Vector3 direction = target.transform.position - transform.position;

        if (direction != Vector3.zero)
        {
            // Поворот в сторону цели
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Устанавливаем полный поворот (и по Y, и по X)
            transform.rotation = targetRotation;
        }
    }
}
