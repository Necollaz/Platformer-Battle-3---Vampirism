using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : HealthUIBase
{
    [SerializeField] private Slider _smoothHealthBar;
    [SerializeField] private float _smoothSpeed = 5f;

    private Coroutine _currentCoroutine;
    private float _stepSize = 0.01f;

    protected override void UpdateHealthUI(float currentHealth, float maxHealth)
    {
        if(_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(UpdateSmoothHealthBar(currentHealth, maxHealth));
    }

    private IEnumerator UpdateSmoothHealthBar(float currentHealth, float maxHealth)
    {
        float targetValue = currentHealth / maxHealth;

        while (Mathf.Abs(_smoothHealthBar.value - targetValue) > _stepSize)
        {
            _smoothHealthBar.value = Mathf.Lerp(_smoothHealthBar.value, targetValue, Time.deltaTime * _smoothSpeed);
            yield return null;
        }

        _smoothHealthBar.value = targetValue;
    }
}
