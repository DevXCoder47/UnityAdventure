using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Killing : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float distanceForKilling;
    [SerializeField] private TMP_Text info;
    [SerializeField] private float timeForText;

    private Collecting collectingScript;
    private FirstPersonMovement fpmScript;
    private bool isDead = false; // Чтобы не запускать корутину несколько раз

    void Start()
    {
        // Получаем ссылки на нужные скрипты, если цель задана
        if (target != null)
        {
            collectingScript = target.GetComponent<Collecting>();
            fpmScript = target.GetComponent<FirstPersonMovement>();
        }
    }

    void Update()
    {
        if (target == null || isDead) return;

        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= distanceForKilling)
        {
            StartCoroutine(ShowDeathMessage());
        }
    }

    private IEnumerator ShowDeathMessage()
    {
        isDead = true;
        if (collectingScript) collectingScript.enabled = false;
        if (fpmScript) fpmScript.enabled = false;
        info.text = "You lost";
        info.color = Color.blue;

        yield return new WaitForSeconds(timeForText);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
