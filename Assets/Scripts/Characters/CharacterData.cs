using System;
using System.Collections.Generic;

[Serializable]
public class CharacterData
{
    public const int MaxDemoLevel = 5;

    public string characterName = "Hero";

    public CharacterClass characterClass;

    public Ability primaryAbility;

    public int level = 1;

    public int maxHP;
    public int currentHP;

    public int armorClass = 10;

    public CharacterStats stats = new CharacterStats();

    public bool IsDead => currentHP <= 0;

    public bool IsMaxLevel => level >= MaxDemoLevel;


public int talentPoints = 0;

public List<string> unlockedTalentIds =
    new List<string>();

    public void Initialize(ClassDatabase classDatabase)
    {
        ClassData classData =
            classDatabase.GetClass(characterClass);

        if (classData == null)
            return;

        maxHP = CalculateMaxHP(classData);
        currentHP = maxHP;
    }


    public bool SetPrimaryAbility(
        Ability ability,
        ClassData classData
    )
    {
        if (!classData.primaryAbilities.Contains(ability))
        {
            return false;
        }

        primaryAbility = ability;

        return true;
    }


    private int CalculateMaxHP(ClassData classData)
    {
        int constitutionModifier =
            stats.GetModifier(Ability.Constitution);

        int baseHP =
            (int)classData.hitDie;

        return Math.Max(
            1,
            baseHP + constitutionModifier
        );
    }


    public bool LevelUp()
{
    if (IsMaxLevel)
    {
        return false;
    }

    level++;

    if (level == 2 || level == 4)
    {
        talentPoints++;
    }

    return true;
}


    public void TakeDamage(int damage)
    {
        currentHP -= Math.Max(0, damage);

        if (currentHP < 0)
        {
            currentHP = 0;
        }
    }


    public void Heal(int amount)
    {
        currentHP += Math.Max(0, amount);

        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }
}