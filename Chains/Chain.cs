using DungeonCrawler.Characters;

namespace DungeonCrawler.Chains;

public class Chain
{
    public static void Chained(AbstractHandler handler)
    {
        handler.Handle(Player.GetInstance());
    }
}