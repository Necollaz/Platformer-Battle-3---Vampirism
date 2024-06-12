using UnityEngine;

public abstract class HealthUIBase : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.HealthChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnValueChanged;
    }

    protected abstract void UpdateHealthUI(float currentHealth, float maxHealth);

    private void OnValueChanged(float currentHealth, float maxHealth)
    {
        UpdateHealthUI(currentHealth, maxHealth);
    }
}
