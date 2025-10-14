using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collecting : MonoBehaviour
{
    [SerializeField] private TMP_Text info;
    [SerializeField] private int maxScore;
    [SerializeField] private float timeForText;

    private int score;
    private Coroutine hideTextCoroutine;

    void OnTriggerEnter(Collider other)
    {
        // проверяем, имеет ли объект тег "Coin"
        if (other.CompareTag("Coin"))
        {
            score++;
            Destroy(other.gameObject);

            // обновляем текст
            info.text = $"{score}/{maxScore}";
            info.gameObject.SetActive(true);

            // если уже запущена корутина скрытия — перезапускаем
            if (hideTextCoroutine != null)
                StopCoroutine(hideTextCoroutine);

            hideTextCoroutine = StartCoroutine(HideTextAfterDelay());
        }

        if(score == maxScore)
        {
            LoadNextSceneOrExit();
        }

    }
    private IEnumerator HideTextAfterDelay()
    {
        yield return new WaitForSeconds(timeForText);
        info.gameObject.SetActive(false);
        hideTextCoroutine = null;
    }

    private void LoadNextSceneOrExit()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
