using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    private float _currentHealth;

    public event Action<float, float> HealthChanged;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
            Destroy(gameObject);
            return;
        }

        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void Heal(int amount)
    {
        _currentHealth += amount;

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }
}
