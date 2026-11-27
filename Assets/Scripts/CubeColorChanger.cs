using UnityEngine;
using UnityEngine.UI;

public class CubeColorChanger : MonoBehaviour
{
    [SerializeField] private Button _actionButton;
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    // Подписываемся на событие при включении объекта
    private void OnEnable()
    {
        _actionButton.onClick.AddListener(ChangeColor);
    }

    // Обязательно отписываемся при выключении, чтобы не было утечек памяти
    private void OnDisable()
    {
        _actionButton.onClick.RemoveListener(ChangeColor);
    }

    private void ChangeColor()
    {
        _renderer.material.color = Random.ColorHSV();
    }
}
