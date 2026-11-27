using UnityEngine;
using UnityEngine.UI;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private Health _targetHealth;
    [SerializeField] private Button _damageButton;
    [SerializeField] private float _damageAmount = 15f;

    private void OnEnable()
    {
        _damageButton.onClick.AddListener(DealDamage);
    }

    private void OnDisable()
    {
        _damageButton.onClick.RemoveListener(DealDamage);
    }

    private void DealDamage()
    {
        _targetHealth.TakeDamage(_damageAmount);
    }
}
