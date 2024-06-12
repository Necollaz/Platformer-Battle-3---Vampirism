using UnityEngine;
using TMPro;

public class HealthText : HealthUIBase
{
    [SerializeField] private TextMeshProUGUI _healthText;

    protected override void UpdateHealthUI(float currenHealth, float maxHealth)
    {
        _healthText.text = $"{currenHealth} / {maxHealth}";
    }
}
