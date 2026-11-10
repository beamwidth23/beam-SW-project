using System.Collections.Generic;
using UnityEngine;

public class SkillSustained : SkillBase
{
    private float distanceToPlayer = 2f;
    private Transform parent;
    private List<GameObject> pickaxs = new List<GameObject>();

    public override void Setup(SkillTemplate skillTemplate, PlayerBase owner, Transform spawnPoint = null)
    {
        base.Setup(skillTemplate, owner, spawnPoint);

        GameObject pickaxsObject = GameObject.Find("Pickaxs");
        if ( pickaxsObject == null )
        {
            Debug.LogError("[SkillSustained] 씬에 \"Pickaxs\" 오브젝트가 없습니다.");
            return;
        }
        parent = pickaxsObject.transform;
    }

    public override void OnLevelUp()
    {
        if ( parent == null ) return;

        if ( currentLevel <= 1 )
        {
            AddPickax((int)GetStat(StatType.ProjectileCount).Value);

            int pickaxCount = parent.childCount;
            for ( int i = 0; i < pickaxCount; ++ i )
            {
                float angle = (360f / pickaxCount) * i;
                Vector3 position = Utils.GetPositionFromAngle(distanceToPlayer, angle);
                parent.GetChild(i).position = parent.position + position;
            }
            return;
        }

        skillTemplate.attackBuffStats.ForEach(stat =>
        {
            GetStat(stat).BonusValue += stat.DefaultValue;
        });

        foreach ( var item in pickaxs )
        {
            item.GetComponent<ProjectileCollision2D>().Setup(null, GetStat(StatType.Damage).Value);
        }
    }

    public override void OnSkill() { }

    /// <summary>
    /// count 개수만큼 곡괭이 발사체를 생성해 parent(Pickaxs)의 자식으로 배치한다.
    /// </summary>
    private void AddPickax(int count)
    {
        for ( int i = 0; i < count; ++ i )
        {
            GameObject clone = GameObject.Instantiate(skillTemplate.projectile, parent);
            clone.GetComponent<ProjectileCollision2D>().Setup(null, GetStat(StatType.Damage).Value);
            pickaxs.Add(clone);
        }
    }
}
