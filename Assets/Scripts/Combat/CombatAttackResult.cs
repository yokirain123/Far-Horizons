public class CombatAttackResult
{
    public DiceRollResult AttackRoll { get; }

    public DiceRollResult DamageRoll { get; }

    public bool Hit { get; }

    public bool Critical { get; }

    public bool UsedPowerStrike { get; }

    public int Damage { get; }

    public int CleaveDamage { get; }


    public CombatAttackResult(
        DiceRollResult attackRoll,
        DiceRollResult damageRoll,
        bool hit,
        bool critical,
        bool usedPowerStrike,
        int damage,
        int cleaveDamage
    )
    {
        AttackRoll = attackRoll;
        DamageRoll = damageRoll;

        Hit = hit;
        Critical = critical;

        UsedPowerStrike = usedPowerStrike;

        Damage = damage;
        CleaveDamage = cleaveDamage;
    }
}