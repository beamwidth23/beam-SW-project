using System.Collections.Generic;
using UnityEngine;

public enum SkillType { Buff = 0, Emission, Sustained, Global, }
public enum SkillElement { None = -1, Ice = 0, Fire, Wind, Light, Dark, Count = 5 }

[CreateAssetMenu(fileName = "NewSkill", menuName = "SkillAsset", order = 0)]
public class SkillTemplate : ScriptableObject
{
    [Header("Common")]
    public string skillName;
    public SkillType skillType;
    public SkillElement element;
    public int maxLevel;
    [TextArea]
    public string description;
    public Sprite enableIcon;
    public Sprite disableIcon;

    [Header("Buff Skill")]
    public List<Stat> buffStatList;

    [Header("Attack Skill")]
    public List<Stat> attackBaseStats;  // 공격 스킬 스탯 정보
    public List<Stat> attackBuffStats;  // 레벨업 시 추가 스탯
    public GameObject projectile;       // 발사체 프리팹
}
