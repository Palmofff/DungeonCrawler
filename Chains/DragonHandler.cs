using DungeonCrawler.Characters;
using DungeonCrawler.Managers;
using DungeonCrawler.Utilities;

namespace DungeonCrawler.Chains;

public class DragonHandler: AbstractHandler
{
    public override object? Handle(object request)
    {
        if (Player.GetInstance().Level == 10)
        {
            Fight.Combat(MonsterManager.SpawnDragon());
        }
        else
        {
            return base.Handle(request);
        }
        return null;
    }
}