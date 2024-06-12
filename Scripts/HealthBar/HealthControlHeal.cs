using UnityEngine;

public class HealthControlHeal : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out MedicineChest medicineChest))
        {
            medicineChest.Use();
        }
    }
}
