namespace DungeonCrawler.Characters;

public abstract class Character
{
    public string? Name { get; set; }
    public int Level { get; set; }
    public float MaxHp { get; set; }
    public float Hp { get; set; }
    public float AttackBonus { get; set; }
    public int[]? Damage { get; set; }
    public float Ac { get; set; }
    public int Experience { get; set; }
}