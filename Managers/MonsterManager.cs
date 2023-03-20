using System.Text.Json;
using DungeonCrawler.Characters;
using DungeonCrawler.Utilities;

namespace DungeonCrawler.Managers;

public class MonsterManager
{
    private static Monster[] LoadMonster()
    {
        var fileName = @"..\..\..\serializables\Monster.json";
        var jsonString = File.ReadAllText(fileName);
        var monsters = JsonSerializer.Deserialize<Monster[]>(jsonString);
        return monsters!;
    }
    
    private static Boss[] LoadBosses()
    {
        var fileName = @"..\..\..\serializables\Boss.json";
        var jsonString = File.ReadAllText(fileName);
        var bosses = JsonSerializer.Deserialize<Boss[]>(jsonString);
        return bosses!;
    }

    public static Monster SpawnMonster()
    {
        var loadedMonsters = LoadMonster()
            .Where(x => x.Level <= Player.GetInstance().Level)
            .ToArray();
        Random rand = new Random();
        int index = rand.Next(loadedMonsters.Length);
        var monster = loadedMonsters[index];
        monster.Level = Player.GetInstance().Level + rand.Next(-1, 2);
        if (monster.Level < 1)
        {
            monster.Level = 1;
        }
        monster.MaxHp = (float)Math.Round(Player.GetInstance().MaxHp * monster.MaxHp * 
                                          Condition.Game.DifficultyMultiplier);
        monster.Hp = monster.MaxHp;
        monster.Ac =  (float)Math.Round(Player.GetInstance().Ac * monster.Ac * 
                                        Condition.Game.DifficultyMultiplier);
        monster.AttackBonus = (float)Math.Round(Player.GetInstance().AttackBonus * monster.AttackBonus
        * Condition.Game.DifficultyMultiplier);
        monster.Experience = (int)Math.Round(monster.Experience * Condition.Game.DifficultyMultiplier
        * monster.Level);
        
        
        return monster;
        
        
    }

    public static Boss SpawnMidBoss()
    {
        var mirrorDemon = LoadBosses()[0];
        mirrorDemon.AttackBonus = Player.GetInstance().AttackBonus;
        mirrorDemon.Ac = Player.GetInstance().Ac;
        mirrorDemon.Damage = Player.GetInstance().Damage;
        mirrorDemon.MaxHp = Player.GetInstance().MaxHp;
        mirrorDemon.Hp = mirrorDemon.MaxHp;
        return mirrorDemon;
    }

    public static Boss SpawnDragon()
    {
        var dragon = LoadBosses()[1];
        dragon.Ac = (float)Math.Round(dragon.Ac*Player.GetInstance().Ac);
        dragon.MaxHp = (float)Math.Round(dragon.MaxHp*Player.GetInstance().MaxHp);
        dragon.Hp = dragon.MaxHp;
        return dragon;
    }
}

