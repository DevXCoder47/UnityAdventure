using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Speaking : MonoBehaviour
{
    [SerializeField] private TMP_Text line;
    [SerializeField] private List<string> dialogueLines;
    [SerializeField] private float timeForLine;

    private Moving movingScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Получаем ссылку на компонент Moving, если он есть на том же объекте
        movingScript = GetComponent<Moving>();
        if (line != null && dialogueLines.Count > 0)
        {
            StartCoroutine(PlayDialogue());
        }
    }

    private IEnumerator PlayDialogue()
    {
        // Проходим по всем репликам
        foreach (string dialogue in dialogueLines)
        {
            line.text = dialogue; // Показываем реплику
            yield return new WaitForSeconds(timeForLine); // Ждём заданное время
        }

        // После последней реплики очищаем текст
        line.text = "";

        // Активируем движение
        if (movingScript != null)
        {
            movingScript.enabled = true;
        }

        //Проверяем, не является ли сцена эпилогом
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentIndex == 4)
        {
            SceneManager.LoadScene(0);
        }

    }
}
