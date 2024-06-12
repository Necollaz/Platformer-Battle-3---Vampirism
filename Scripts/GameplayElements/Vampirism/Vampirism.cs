using System.Collections;
using UnityEngine;

[RequireComponent(typeof (Health))]
public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _radius = 5f;
    [SerializeField] private VampirismDetected _detected;
    [SerializeField] private float _duration = 6f;
    [SerializeField] private float _drainRate = 10f;

    private Health _playerHealth;
    private Coroutine _coroutine;

    public float Radius => _radius;

    private void Awake()
    {
        _playerHealth = GetComponent<Health>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if(_coroutine == null)
            {
                Enemy nearestEnemy = GetNearestEnemy();

                if(nearestEnemy != null)
                {
                    _coroutine = StartCoroutine(VampirismAbility(nearestEnemy));
                }
            }
        }
    }

    private Enemy GetNearestEnemy()
    {
        Enemy nearestEnemy = null;
        float shortestDistance = float.MaxValue;

        foreach (var enemy in _detected.EnemyDetected)
        {
            if (enemy == null) continue;

            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if(distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }

    private IEnumerator VampirismAbility(Enemy targetEnemy)
    {
        Health enemyHealth = targetEnemy.GetComponent<Health>();

        if (enemyHealth == null) yield break;

        float elapsedTime = 0f;

        while(elapsedTime < _duration)
        {
            float drainAmount = _drainRate * Time.deltaTime;

            enemyHealth.TakeDamage((int)drainAmount);
            _playerHealth.Heal((int)drainAmount);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _coroutine = null;
    }
}
