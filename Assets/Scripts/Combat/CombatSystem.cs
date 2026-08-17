using System;
using UnityEngine;

public static class CombatSystem
{
    private const int PowerStrikeAttackPenalty = 2;
    private const int PowerStrikeDamageBonus = 4;


    public static CombatAttackResult Attack(
        CharacterData attacker,
        EnemyData target,
        DiceType weaponDie,
        bool usePowerStrike = false,
        EnemyData secondaryTarget = null
    )
    {
        if (attacker == null)
        {
            Debug.LogError("Attacker is null.");

            return null;
        }

        if (target == null)
        {
            Debug.LogError("Target is null.");

            return null;
        }

        if (target.IsDead)
        {
            Debug.LogWarning(
                $"{target.enemyName} is already dead."
            );

            return null;
        }


        // =========================
        // ATTACK MODIFIER
        // =========================

        int abilityModifier =
            attacker.stats.GetModifier(
                attacker.primaryAbility
            );

        int attackModifier =
            abilityModifier +
            attacker.stats.proficiencyBonus;


        // =========================
        // POWER STRIKE
        // =========================

        bool powerStrikeActive =
            usePowerStrike &&
            TalentSystem.HasTalent(
                attacker,
                TalentIds.Fighter.PowerStrike
            );

        if (powerStrikeActive)
        {
            attackModifier -=
                PowerStrikeAttackPenalty;
        }


        // =========================
        // ATTACK ROLL
        // =========================

        DiceRollResult attackRoll =
            DiceSystem.RollD20(
                attackModifier
            );


        // =========================
        // CRITICAL RANGE
        // =========================

        int criticalThreshold = 20;

        if (
            TalentSystem.HasTalent(
                attacker,
                TalentIds.Fighter.ImprovedCritical
            )
        )
        {
            criticalThreshold = 19;
        }


        bool critical =
            attackRoll.NaturalRoll >=
            criticalThreshold;


        // Natural 1 always misses.
        bool hit;

        if (attackRoll.IsNatural1)
        {
            hit = false;
            critical = false;
        }
        else if (critical)
        {
            hit = true;
        }
        else
        {
            hit =
                attackRoll.Total >=
                target.armorClass;
        }


        // =========================
        // MISS
        // =========================

        if (!hit)
        {
            Debug.Log(
                $"{attacker.characterName} attacks " +
                $"{target.enemyName}\n" +
                $"Roll: {attackRoll.NaturalRoll} " +
                $"({attackRoll.Total} total)\n" +
                $"AC: {target.armorClass}\n" +
                $"MISS"
            );

            return new CombatAttackResult(
                attackRoll,
                null,
                false,
                false,
                powerStrikeActive,
                0,
                0
            );
        }


        // =========================
        // DAMAGE
        // =========================

        int weaponDiceCount =
            critical ? 2 : 1;

        DiceRollResult damageRoll =
            DiceSystem.Roll(
                weaponDie,
                weaponDiceCount,
                abilityModifier
            );

        int damage =
            damageRoll.Total;


        // =========================
        // POWER STRIKE DAMAGE
        // =========================

        if (powerStrikeActive)
        {
            damage +=
                PowerStrikeDamageBonus;
        }


        damage =
            Math.Max(1, damage);

        target.TakeDamage(damage);


        // =========================
        // CLEAVE
        // =========================

        int cleaveDamage = 0;

        bool hasCleave =
            TalentSystem.HasTalent(
                attacker,
                TalentIds.Fighter.Cleave
            );

        if (
            hasCleave &&
            secondaryTarget != null &&
            !secondaryTarget.IsDead
        )
        {
            cleaveDamage =
                Math.Max(
                    1,
                    damage / 2
                );

            secondaryTarget.TakeDamage(
                cleaveDamage
            );
        }


        // =========================
        // DEBUG
        // =========================

        string criticalText =
            critical
                ? "\nCRITICAL HIT!"
                : "";

        string powerStrikeText =
            powerStrikeActive
                ? "\nPOWER STRIKE"
                : "";

        string cleaveText =
            cleaveDamage > 0
                ? $"\nCLEAVE → " +
                  $"{secondaryTarget.enemyName}: " +
                  $"{cleaveDamage} damage"
                : "";

        Debug.Log(
            $"{attacker.characterName} attacks " +
            $"{target.enemyName}\n" +
            $"Roll: {attackRoll.NaturalRoll} " +
            $"({attackRoll.Total} total)\n" +
            $"AC: {target.armorClass}" +
            criticalText +
            powerStrikeText +
            $"\nDamage: {damage}" +
            cleaveText
        );


        return new CombatAttackResult(
            attackRoll,
            damageRoll,
            true,
            critical,
            powerStrikeActive,
            damage,
            cleaveDamage
        );
    }
}