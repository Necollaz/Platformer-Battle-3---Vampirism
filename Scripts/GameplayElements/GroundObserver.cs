using System;
using UnityEngine;

public class GroundObserver : MonoBehaviour
{
    public event Action OnLanded;
    public event Action OnAirborne;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground _))
        {
            OnLanded?.Invoke();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground _))
        {
            OnAirborne?.Invoke();
        }
    }
}