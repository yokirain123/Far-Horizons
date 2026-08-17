public static class SkillCheckSystem
{
    public static SkillCheckResult MakeCheck(
        CharacterStats stats,
        Skill skill,
        int dc,
        RollMode rollMode = RollMode.Normal
    )
    {
        Ability ability =
            SkillDatabase.GetAbility(skill);

        int abilityModifier =
            stats.GetModifier(ability);

        int proficiencyBonus =
            stats.IsProficient(skill)
                ? stats.proficiencyBonus
                : 0;

        DiceRollResult roll =
            DiceSystem.RollD20(
                modifier: 0,
                mode: rollMode
            );

        return new SkillCheckResult(
            roll,
            skill,
            ability,
            abilityModifier,
            proficiencyBonus,
            dc
        );
    }
}