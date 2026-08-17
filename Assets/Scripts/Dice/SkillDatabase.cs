public static class SkillDatabase
{
    public static Ability GetAbility(Skill skill)
    {
        return skill switch
        {
            Skill.Athletics => Ability.Strength,

            Skill.Acrobatics => Ability.Dexterity,
            Skill.SleightOfHand => Ability.Dexterity,
            Skill.Stealth => Ability.Dexterity,

            Skill.Arcana => Ability.Intelligence,
            Skill.History => Ability.Intelligence,
            Skill.Investigation => Ability.Intelligence,

            Skill.Insight => Ability.Wisdom,
            Skill.Medicine => Ability.Wisdom,
            Skill.Perception => Ability.Wisdom,
            Skill.Survival => Ability.Wisdom,

            Skill.Deception => Ability.Charisma,
            Skill.Intimidation => Ability.Charisma,
            Skill.Performance => Ability.Charisma,
            Skill.Persuasion => Ability.Charisma,

            _ => Ability.Strength
        };
    }
}