using UnityEngine;

public class PlayerBase : EntityBase
{
    [SerializeField]
    private FollowTarget targetMark;

    public bool IsMoved { get; set; } = false;

    private void Awake()
    {
        base.Setup();
    }

    private void Update()
    {
        if ( Target == null ) targetMark.gameObject.SetActive(false);

        SearchTarget();
        Recovery();
    }

    private void SearchTarget()
    {
        float closestDistSqr = Mathf.Infinity;
        Target = null;

        foreach ( var entity in EnemySpawner.Enemies )
        {
            if ( entity == null || entity.IsDead ) continue;

            float distance = (entity.transform.position - transform.position).sqrMagnitude;
            if ( distance < closestDistSqr )
            {
                closestDistSqr = distance;
                Target = entity.GetComponent<EntityBase>();
            }
        }

        if ( Target != null )
        {
            targetMark.SetTarget(Target.transform);
            targetMark.transform.position = Target.transform.position;
            targetMark.gameObject.SetActive(true);
        }
    }

    private void Recovery()
    {
        // 체력 회복
        if ( Stats.CurrentHP.DefaultValue < Stats.GetStat(StatType.HP).Value )
            Stats.CurrentHP.DefaultValue +=
                Time.deltaTime * Stats.GetStat(StatType.HPRecovery).Value;
        else
            Stats.CurrentHP.DefaultValue = Stats.GetStat(StatType.HP).Value;
    }
}
