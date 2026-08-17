using UnityEngine;

public static class TalentSystem
{
    public static bool CanUnlock(
        CharacterData character,
        ClassData classData,
        TalentData talent
    )
    {
        if (character == null ||
            classData == null ||
            talent == null)
        {
            return false;
        }

        if (character.characterClass != talent.characterClass)
        {
            return false;
        }

        if (character.level < talent.requiredLevel)
        {
            return false;
        }

        if (character.talentPoints <= 0)
        {
            return false;
        }

        if (!classData.talents.Contains(talent))
        {
            return false;
        }

        if (HasTalent(character, talent))
        {
            return false;
        }

        return true;
    }


    public static bool UnlockTalent(
        CharacterData character,
        ClassData classData,
        TalentData talent
    )
    {
        if (!CanUnlock(
            character,
            classData,
            talent
        ))
        {
            return false;
        }

        character.unlockedTalentIds.Add(
            talent.talentId
        );

        character.talentPoints--;

        Debug.Log(
            $"{character.characterName} unlocked talent: " +
            $"{talent.displayName}"
        );

        return true;
    }


    public static bool HasTalent(
        CharacterData character,
        TalentData talent
    )
    {
        return character.unlockedTalentIds.Contains(
            talent.talentId
        );
    }


    public static bool HasTalent(
        CharacterData character,
        string talentId
    )
    {
        return character.unlockedTalentIds.Contains(
            talentId
        );
    }
}