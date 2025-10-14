using UnityEngine;

public class Following : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float maxDistanceToTarget;
    [SerializeField] private float minDistanceToTarget;
    [SerializeField] private float speed;

    private Speaking speakingScript;
    private bool dialogueIsTold = false;
    void Start()
    {
        speakingScript = GetComponent<Speaking>();
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
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        if(distance <= minDistanceToTarget && !dialogueIsTold)
        {
            if(speakingScript) speakingScript.enabled = true;
            dialogueIsTold = true;
        }
    }
}
