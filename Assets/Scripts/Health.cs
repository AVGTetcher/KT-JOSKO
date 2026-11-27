using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    private float _currentHealth;

    // Событие: передаёт текущее здоровье и максимальное
    public event Action<float, float> HealthChanged;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    private void Start()
    {
        // На старте сообщаем UI, что ХП полное
        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0) return;

        // Не даём здоровью уйти ниже нуля
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0f, _maxHealth);

        // Оповещаем всех подписчиков, что здоровье изменилось
        HealthChanged?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
        {
            Debug.Log("Персонаж помер!");
        }
    }
}
