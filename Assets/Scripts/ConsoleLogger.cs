using UnityEngine;
using UnityEngine.UI;

public class ConsoleLogger : MonoBehaviour
{
    [SerializeField] private Button _actionButton;

    private void Awake()
    {
        // Если забыл закинуть кнопку в инспектор — скрипт найдёт её сам
        if (_actionButton == null)
        {
            _actionButton = FindAnyObjectByType<Button>();
        }
    }

    private void Start()
    {
        Debug.Log("Скрипт ConsoleLogger жив и готов к работе!");
    }

    private void OnEnable()
    {
        if (_actionButton != null)
            _actionButton.onClick.AddListener(LogMessage);
    }

    private void OnDisable()
    {
        if (_actionButton != null)
            _actionButton.onClick.RemoveListener(LogMessage);
    }

    private void LogMessage()
    {
        Debug.Log("Кнопка нажата! Третий объект отреагировал.");
    }
}