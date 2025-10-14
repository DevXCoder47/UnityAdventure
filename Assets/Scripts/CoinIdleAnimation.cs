using UnityEngine;

public class CoinIdleAnimation : MonoBehaviour
{
    [SerializeField] private float speed;          // скорость колебаний вверх-вниз
    [SerializeField] private float altitude;     // высота колебаний
    [SerializeField] private float rotationSpeed; // скорость вращения

    private Vector3 startPosition;

    void Start()
    {
        // Запоминаем исходную позицию монетки
        startPosition = transform.position;
    }

    void Update()
    {
        // Движение вверх-вниз по синусоиде
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * altitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);

        // Вращение вокруг оси Y
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }
}
