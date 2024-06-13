using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int _damageAmount = 10;
    [SerializeField] private float _attackRange = 1.5f;
    [SerializeField] private float _attackCooldown = 3f;
    [SerializeField] private LayerMask _playerLayer;

    private bool _isAttacking = false;
    private float _nextAttackTime;

    private void Update()
    {
        if (_isAttacking)
            PerformAttack();
    }

    public void StartAttack()
    {
        if(Time.time >= _nextAttackTime)
        {
            _isAttacking = true;
            _nextAttackTime = Time.time + _attackCooldown;
        }
    }

    public void StopAttack()
    {
        _isAttacking = false;
    }

    private void PerformAttack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(transform.position, _attackRange, _playerLayer);

        foreach (Collider2D player in hitPlayer)
        {
            if (player.TryGetComponent(out Health health))
                health.TakeDamage(_damageAmount);
        }

        StopAttack();
    }
}
