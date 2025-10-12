using UnityEngine;

public class Hower : MonoBehaviour
{
    [SerializeField] private float distanceToGround;  // Высота над Terrain
    [SerializeField] private float smoothSpeed;        // Скорость сглаживания

    void Update()
    {
        // Проверяем, есть ли Terrain под объектом
        if (Terrain.activeTerrain != null)
        {
            // Получаем высоту поверхности Terrain под этим объектом
            float terrainHeight = Terrain.activeTerrain.SampleHeight(transform.position);

            // Позиция, на которой объект должен быть
            float targetY = terrainHeight + distanceToGround;

            // Плавно перемещаем объект по Y
            Vector3 targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothSpeed);
        }
    }
}
