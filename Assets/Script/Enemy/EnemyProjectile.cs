using UnityEngine;

[RequireComponent(typeof(MovemenRigidbody2D))]
public class EnemyProjectile : MonoBehaviour
{
    private MovemenRigidbody2D movementRigidbody2D;
    private ScaleEffect scaleEffect;
    private float damage;

    public void Setup(Vector3 target, float damage)
    {
        movementRigidbody2D = GetComponent<MovemenRigidbody2D>();
        scaleEffect = GetComponent<ScaleEffect>();
        this.damage = damage;

        scaleEffect.Play(transform.localScale * 0.2f, transform.localScale);
        movementRigidbody2D.MoveTo((target - transform.position).normalized);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Player") && collision.TryGetComponent<EntityBase>(out var entity))
        {
            entity.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}