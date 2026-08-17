using System;

[Serializable]
public class EnemyData
{
    public string enemyName = "Enemy";

    public int maxHP = 10;
    public int currentHP = 10;

    public int armorClass = 10;

    public bool IsDead =>
        currentHP <= 0;


    public void TakeDamage(int damage)
    {
        damage = Math.Max(0, damage);

        currentHP -= damage;

        if (currentHP < 0)
        {
            currentHP = 0;
        }
    }


    public void Heal(int amount)
    {
        amount = Math.Max(0, amount);

        currentHP += amount;

        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }
}