using UnityEngine;

public class ProjectileHoming : ProjectileBase
{
    private EntityBase target;

    public override void Setup(EntityBase target, float damage)
    {
        base.Setup(target, damage);

        this.target = target;
    }

    public override void Process()
    {
        if ( target == null || target.IsDead )
        {
            FindTarget();
            return;
        }

        // 발사체를 목표 방향으로 회전
        transform.rotation = Utils.RotateToTarget(transform.position,
            target.MiddlePoint, 90);
        // 발사체 이동 방향 설정
        movementRigidbody2D.MoveTo((target.MiddlePoint -
            transform.position).normalized);
    }

    private void FindTarget()
    {
        if ( EnemySpawner.Enemies.Count > 0 )
        {
            EntityBase nextTarget = null;
            for ( int i = 0; i < EnemySpawner.Enemies.Count; ++ i )
            {
                if ( EnemySpawner.Enemies[i] != null && !EnemySpawner.Enemies[i].IsDead )
                {
                    nextTarget = EnemySpawner.Enemies[i];
                    break;
                }
            }

            if ( nextTarget != null )
            {
                target = nextTarget;
                GetComponent<ProjectileCollision2D>().SetTarget(target);
            }
            else Destroy(gameObject);
        }
        else Destroy(gameObject);
    }
}
