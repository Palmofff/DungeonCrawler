using DungeonCrawler.Utilities;

namespace DungeonCrawler.Chains;

public class LevelsHandler : AbstractHandler
{
    public override object? Handle(object request)
    {
        Leveling.LevelUp();
        return base.Handle(request);
    }
}