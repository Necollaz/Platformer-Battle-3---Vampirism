using UnityEngine;

public class HealthControlDamage : MonoBehaviour
{
    [SerializeField] private int _damageAmount = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Health health))
        {
            health.TakeDamage(_damageAmount);
        }
    }
}
