using DungeonCrawler.Utilities;

namespace DungeonCrawler.Managers;

public class LabManager
{
    private static List<string> _labWay = new List<string>() {"right", "left", "straight" };
    public static void RightWay()
    {
        Condition.Game.DifficultyMultiplier = 1;
        var rand = new Random();
        var wayRandom = rand.Next(1, 101);
        if (wayRandom <= 25)
            Treasure.Treasure.Chest();
        else if (wayRandom is > 25 and <= 95)
        {
            Fight.Combat(MonsterManager.SpawnMonster());
        }
        else
        {
            Typing.WriteSlow("Dead end, go away and try another tunnel branch");
            Typing.WriteSlow("What side do you want to go? Choose:");
            var way = Console.ReadLine();
            while (!_labWay.Contains(way!) || way == "right")
            {
                Typing.WriteSlow("Error, choose only from left, straight:");
                way = Console.ReadLine();
                
            }
            if (way == "straight")
            {
                wayRandom = rand.Next(1, 101);
                if (wayRandom <= 45)
                {
                    Treasure.Treasure.Chest();
                }
                else
                {
                    Condition.Game.DifficultyMultiplier = 0.8;
                    Fight.Combat(MonsterManager.SpawnMonster());
                }
            }
            else if (way == "left")
            {
                wayRandom = rand.Next(1, 101);
                if (wayRandom <= 30)
                {
                    Treasure.Treasure.Chest();
                }
                else
                {
                    Condition.Game.DifficultyMultiplier = 0.6;
                    Fight.Combat(MonsterManager.SpawnMonster());
                }
            }
        }
    }

    public static void StraightWay()
    {
        Condition.Game.DifficultyMultiplier = 0.8;
        var rand = new Random();
        var wayRandom = rand.Next(1, 101);
        if (wayRandom <= 20)
            Treasure.Treasure.Chest();
        else if (wayRandom is > 20 and <= 95)
        {
            Fight.Combat(MonsterManager.SpawnMonster());
        }
        else
        {
            Typing.WriteSlow("Dead end, go away and try another tunnel branch");
            Typing.WriteSlow("What side do you want to go? Choose:");
            var way = Console.ReadLine();
            while (!_labWay.Contains(way!) || way == "straight")
            {
                Typing.WriteSlow("Error, choose only from left, right:");
                way = Console.ReadLine();
                
            }
            if (way == "right" )
            {
                wayRandom = rand.Next(1, 101);
                if (wayRandom <= 45)
                {
                    Treasure.Treasure.Chest();
                }
                else
                {
                    Condition.Game.DifficultyMultiplier = 1;
                    Fight.Combat(MonsterManager.SpawnMonster());
                }
            }
            else if (way == "left")
            {
                wayRandom = rand.Next(1, 101);
                if (wayRandom <= 30)
                {
                    Treasure.Treasure.Chest();
                }
                else
                {
                    Condition.Game.DifficultyMultiplier = 0.6;
                    Fight.Combat(MonsterManager.SpawnMonster());
                }
            }
        }
    }
    
    public static void LeftWay()
    {
        Condition.Game.DifficultyMultiplier = 0.6;
        var rand = new Random();
        var wayRandom = rand.Next(1, 101);
        if (wayRandom <= 15)
            Treasure.Treasure.Chest();
        else if (wayRandom is > 15 and <= 95)
        {
            Fight.Combat(MonsterManager.SpawnMonster());
        }
        else
        {
            Typing.WriteSlow("Dead end, go away and try another tunnel branch");
            Typing.WriteSlow("What side do you want to go? Choose:");
            var way = Console.ReadLine();
            while (!_labWay.Contains(way!) || way == "left")
            {
                Typing.WriteSlow("Error, choose only from straight, right:");
                way = Console.ReadLine();
                
            }
            if (way == "right" )
            {
                wayRandom = rand.Next(1, 101);
                if (wayRandom <= 45)
                {
                    Treasure.Treasure.Chest();
                }
                else
                {
                    Condition.Game.DifficultyMultiplier = 1;
                    Fight.Combat(MonsterManager.SpawnMonster());
                }
            }
            else if (way == "straight")
            {
                wayRandom = rand.Next(1, 101);
                if (wayRandom <= 40)
                {
                    Treasure.Treasure.Chest();
                }
                else
                {
                    Condition.Game.DifficultyMultiplier = 0.8;
                    Fight.Combat(MonsterManager.SpawnMonster());
                }
            }
        }
    }
}