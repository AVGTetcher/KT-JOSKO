using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Image _barFill;

    private void OnEnable()
    {
        _health.HealthChanged += UpdateBar;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= UpdateBar;
    }

    private void UpdateBar(float currentHealth, float maxHealth)
    {
        // Считаем процент здоровья (от 0.0 до 1.0) и меняем заливку
        _barFill.fillAmount = currentHealth / maxHealth;
    }
}
