using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject flashlight;
    // Update is called once per frame
    void Update()
    {
        // Проверяем, нажата ли клавиша F в этом кадре
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Переключаем активность объекта
            flashlight.SetActive(!flashlight.activeSelf);
        }
    }
}
