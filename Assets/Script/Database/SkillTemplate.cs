using System.Collections.Generic;
using UnityEngine;

public enum SkillType { Buff = 0, Emission, Sustained, Global, }
public enum SkillElement { None = -1, Ice = 0, Fire, Wind, Light, Dark }

[CreateAssetMenu(fileName = "NewSkill", menuName = "ScriptableObjects/Skill", order = 1)]
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
}
