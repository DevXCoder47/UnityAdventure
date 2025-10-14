using UnityEngine;

public class HostileFollowing : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float maxDistanceToTarget;
    [SerializeField] private float minDistanceToTarget;
    [SerializeField] private float speed;

    private HostileMoving hostileMovingScript;
    private Killing killingScript;
    void Start()
    {
        hostileMovingScript = GetComponent<HostileMoving>();
        killingScript = GetComponent<Killing>();
    }
    void Update()
    {
        if (target == null)
            return;

        // Расстояние до цели
        float distance = Vector3.Distance(transform.position, target.transform.position);

        // Если объект находится слишком далеко — движемся к цели
        if (distance > minDistanceToTarget && distance < maxDistanceToTarget)
        {
            if (hostileMovingScript && hostileMovingScript.enabled) hostileMovingScript.enabled = false;
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }

        if(distance <= minDistanceToTarget) 
        {
            if (killingScript && !killingScript.enabled) killingScript.enabled = true;
        }

        if (distance >= maxDistanceToTarget)
        {
            if (hostileMovingScript && !hostileMovingScript.enabled) hostileMovingScript.enabled = true;
        }
    }
}
