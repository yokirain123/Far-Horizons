public class SkillCheckResult
{
    public DiceRollResult Roll { get; }

    public Skill Skill { get; }

    public Ability Ability { get; }

    public int AbilityModifier { get; }

    public int ProficiencyBonus { get; }

    public int DC { get; }

    public int Total { get; }

    public bool Success { get; }

    public bool IsProficient =>
        ProficiencyBonus > 0;

    public SkillCheckResult(
        DiceRollResult roll,
        Skill skill,
        Ability ability,
        int abilityModifier,
        int proficiencyBonus,
        int dc
    )
    {
        Roll = roll;
        Skill = skill;
        Ability = ability;
        AbilityModifier = abilityModifier;
        ProficiencyBonus = proficiencyBonus;
        DC = dc;

        Total =
            roll.NaturalRoll +
            abilityModifier +
            proficiencyBonus;

        Success = Total >= DC;
    }
}