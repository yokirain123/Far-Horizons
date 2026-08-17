using System.Collections.Generic;

public class DiceRollResult
{
    public DiceType DiceType { get; }
    public List<int> Rolls { get; }

    public int Modifier { get; }

    public int DiceTotal { get; }
    public int Total { get; }

    public int NaturalRoll { get; }

    public bool IsNatural20 =>
        DiceType == DiceType.D20 &&
        NaturalRoll == 20;

    public bool IsNatural1 =>
        DiceType == DiceType.D20 &&
        NaturalRoll == 1;

    public DiceRollResult(
        DiceType diceType,
        List<int> rolls,
        int modifier,
        int diceTotal,
        int naturalRoll
    )
    {
        DiceType = diceType;
        Rolls = rolls;
        Modifier = modifier;
        DiceTotal = diceTotal;
        Total = diceTotal + modifier;
        NaturalRoll = naturalRoll;
    }
}