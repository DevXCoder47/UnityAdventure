using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void NewGame()
    {
        // Загружаем следующую сцену в списке Build Settings
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        // Если в редакторе — останавливаем Play Mode
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Если сборка — закрываем приложение
        Application.Quit();
#endif
    }
}
