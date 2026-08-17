using System.Collections.Generic;
using UnityEngine;

public static class DiceSystem
{
    public static DiceRollResult Roll(
        DiceType diceType,
        int count = 1,
        int modifier = 0
    )
    {
        List<int> rolls = new List<int>();

        int sides = (int)diceType;
        int diceTotal = 0;

        for (int i = 0; i < count; i++)
        {
            int roll = Random.Range(1, sides + 1);

            rolls.Add(roll);
            diceTotal += roll;
        }

        int naturalRoll = count == 1
            ? rolls[0]
            : 0;

        return new DiceRollResult(
            diceType,
            rolls,
            modifier,
            diceTotal,
            naturalRoll
        );
    }


    public static DiceRollResult RollD20(
        int modifier = 0,
        RollMode mode = RollMode.Normal
    )
    {
        if (mode == RollMode.Normal)
        {
            return Roll(
                DiceType.D20,
                1,
                modifier
            );
        }

        int firstRoll = Random.Range(1, 21);
        int secondRoll = Random.Range(1, 21);

        int selectedRoll;

        if (mode == RollMode.Advantage)
        {
            selectedRoll = Mathf.Max(
                firstRoll,
                secondRoll
            );
        }
        else
        {
            selectedRoll = Mathf.Min(
                firstRoll,
                secondRoll
            );
        }

        List<int> rolls = new List<int>
        {
            firstRoll,
            secondRoll
        };

        return new DiceRollResult(
            DiceType.D20,
            rolls,
            modifier,
            selectedRoll,
            selectedRoll
        );
    }
}