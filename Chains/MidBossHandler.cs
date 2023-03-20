using DungeonCrawler.Characters;
using DungeonCrawler.Managers;
using DungeonCrawler.Utilities;

namespace DungeonCrawler.Chains;

public class MidBossHandler: AbstractHandler
{
    public override object? Handle(object request)
    {
        var ways = new List<string>() {"right", "left"};
        if (Player.GetInstance().Level == 5 && 
            Condition.Game is { MidBossDone: false, MidBossSkipped: false })
        {
            Typing.WriteSlow("You can see a tunnel branch at left and a huge door at right.");
            Typing.WriteSlow("Where you want to go? Type only left or right.");
            var way = Console.ReadLine();
            while (!ways.Contains(way!))
            {
                Typing.WriteSlow("Error!ype only left or right!");
                way = Console.ReadLine();
            }

            switch (way)
            {
                case"right":
                    Fight.Combat(MonsterManager.SpawnMidBoss());
                    break;
                case"left":
                    Typing.WriteSlow("You walked for 10 minutes and got to the crossroads.");
                    Condition.Game.MidBossSkipped = true;
                    return base.Handle(request);
                
            }
        }
        else
        {
            return base.Handle(request);
        }
        return null;
    }
}