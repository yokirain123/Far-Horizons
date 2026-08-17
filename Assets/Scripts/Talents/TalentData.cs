using UnityEngine;

[CreateAssetMenu(
    fileName = "NewTalent",
    menuName = "Far Horizons/RPG/Talent"
)]
public class TalentData : ScriptableObject
{
    [Header("Identity")]
    public string talentId;

    public string displayName;

    [TextArea(2, 6)]
    public string description;


    [Header("Requirements")]
    public CharacterClass characterClass;

    [Range(1, 5)]
    public int requiredLevel = 2;


    [Header("Effect")]
    public TalentEffectType effectType;
}