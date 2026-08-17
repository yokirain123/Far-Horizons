using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterStats
{
    public int strength = 10;
    public int dexterity = 10;
    public int constitution = 10;
    public int intelligence = 10;
    public int wisdom = 10;
    public int charisma = 10;

    public int proficiencyBonus = 2;

    public List<Skill> proficientSkills = new List<Skill>();

    public int GetScore(Ability ability)
    {
        return ability switch
        {
            Ability.Strength => strength,
            Ability.Dexterity => dexterity,
            Ability.Constitution => constitution,
            Ability.Intelligence => intelligence,
            Ability.Wisdom => wisdom,
            Ability.Charisma => charisma,
            _ => 10
        };
    }

    public int GetModifier(Ability ability)
    {
        int score = GetScore(ability);

        return Mathf.FloorToInt(
            (score - 10) / 2f
        );
    }

    public bool IsProficient(Skill skill)
    {
        return proficientSkills.Contains(skill);
    }
}