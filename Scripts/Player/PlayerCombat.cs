using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private float _reloadTime;
    [SerializeField] private int _damageAmount = 10;

    private Animator _animator;
    private bool _canHit = true;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Attack();
    }

    public void HitEnemy(GameObject enemy)
    {
        if (enemy.TryGetComponent(out Health health))
            health.TakeDamage(_damageAmount);
    }

    private void Attack()
    {
        if (Input.GetMouseButton(0) && _canHit)
        {
            _animator.SetTrigger(PlayerAnimationData.Params.Attack);
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        _canHit = false;
        yield return new WaitForSeconds(_reloadTime);
        _canHit = true;
    }
}
