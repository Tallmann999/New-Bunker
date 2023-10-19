using UnityEngine;

public class DetectionFireControl : MonoBehaviour
{
    [SerializeField] private FireParticle _fireParticle;
    [SerializeField] private Collider2D _detectionCollider;
    [SerializeField] private int _damage;

    private void OnEnable()
    {
        _fireParticle.ParticlActivated += OnToogleControl;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
        }
    }

    private void OnDisable()
    {
        _fireParticle.ParticlActivated -= OnToogleControl;
    }

    private void OnToogleControl(bool toggle)
    {
        _detectionCollider.enabled = toggle;
    }
}
