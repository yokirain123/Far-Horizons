using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(
    fileName = "NewClassData",
    menuName = "Far Horizons/RPG/Class Data"
)]
public class ClassData : ScriptableObject
{
    [Header("Identity")]
    public CharacterClass classType;

    public string displayName;

    [TextArea(3, 8)]
    public string description;


    [Header("Core")]
    public DiceType hitDie;

    [Header("Primary Abilities")]
public List<Ability> primaryAbilities = new List<Ability>();


    [Header("Saving Throws")]
    public List<Ability> savingThrowProficiencies =
        new List<Ability>();


    [Header("Skills")]
    public int skillChoices = 2;

    public List<Skill> availableSkills =
        new List<Skill>();


    [Header("Defense")]
public DefenseType defenseType = DefenseType.Normal;

    [Header("Training")]
    public List<ArmorTraining> armorTraining =
        new List<ArmorTraining>();

    public List<WeaponTraining> weaponTraining =
        new List<WeaponTraining>();


    [Header("Spellcasting")]
    public bool usesSpellcasting;

    public Ability spellcastingAbility;

    [Header("Talents")]
public List<TalentData> talents =
    new List<TalentData>();
}