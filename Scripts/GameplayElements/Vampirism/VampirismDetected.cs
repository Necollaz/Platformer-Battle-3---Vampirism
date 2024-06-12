using System.Collections.Generic;
using UnityEngine;

public class VampirismDetected : MonoBehaviour
{
    private List<Enemy> _enemyDetected = new List<Enemy>();

    public List<Enemy> EnemyDetected => _enemyDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            _enemyDetected.Add(enemy);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            _enemyDetected.Remove(enemy);
    }
}
