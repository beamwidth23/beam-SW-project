using UnityEngine;

public class PlayerBase : EntityBase
{
    [SerializeField]
    private FollowTarget targetMark;
    public bool IsMoved { get; set;} = false;

    private void Awake()
    {
        base.Setup();
    }
    private void Update()
    {
        if ( Target == null) targetMark.gameObject.SetActive(false);

        SearchTarget();
        
    }
    private void SearchTarget()
    {
       float closesDistSqr = Mathf.Infinity;

       foreach (var entity in EnemySpawner.Enemies)
       {
            
            float distance = (entity.transform.position - transform.position).sqrMagnitude;
            if ( distance < closesDistSqr )
            {
                closesDistSqr = distance;
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
}