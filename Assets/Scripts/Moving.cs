using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float stopThreshold; 

    private Following followingScript;
    private Rotation rotationScript;
    private bool isMoving = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Если нет цели — ничего не делаем
        if (destination == null)
        {
            enabled = false;
            return;
        }

        // Получаем ссылки на другие скрипты
        followingScript = GetComponent<Following>();
        rotationScript = GetComponent<Rotation>();

        // Отключаем их на время движения
        if (followingScript) followingScript.enabled = false;
        if (rotationScript) rotationScript.enabled = false;

        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving || destination == null) return;

        // 1) Поворачиваемся к цели (плавно)
        Vector3 toTarget = destination.position - transform.position;
        // Если цель на том же месте — пропускаем поворот
        if (toTarget.sqrMagnitude > 0f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(toTarget.normalized);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // 2) Двигаемся к цели с помощью MoveTowards (не позволит проскочить)
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);
        transform.position = newPos;

        // 3) Проверка достижения — через квадрат расстояния (чуть быстрее)
        float sqrDist = (destination.position - transform.position).sqrMagnitude;
        if (sqrDist <= stopThreshold * stopThreshold)
        {
            FinishMoving();
            return;
        }

        // Доп. защита на случай, если MoveTowards вернул точно позицию цели
        if (transform.position == destination.position)
        {
            FinishMoving();
            return;
        }
    }

    private void FinishMoving()
    {
        isMoving = false;

        // Включаем обратно другие скрипты
        if (rotationScript && !rotationScript.enabled) rotationScript.enabled = true;

        // Деактивируем этот скрипт, чтобы не мешал
        enabled = false;
    }
}
