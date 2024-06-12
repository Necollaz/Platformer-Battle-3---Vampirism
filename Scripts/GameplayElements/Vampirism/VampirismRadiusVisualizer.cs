using UnityEngine;

public class VampirismRadiusVisualizer : MonoBehaviour
{
    [SerializeField] private float _radius = 5f;
    [SerializeField] private Color _radiusColor = Color.red;

    private void OnDrawGizmos()
    {
        Gizmos.color = _radiusColor;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

    private void OnValidate()
    {
        if(TryGetComponent(out Vampirism vampirism))
        {
            _radius = vampirism.Radius;
        }
    }
}
