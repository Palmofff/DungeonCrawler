using DungeonCrawler.Characters;
using DungeonCrawler.Utilities;

namespace DungeonCrawler.Chains;

public class DeathHandler: AbstractHandler
{
    public override object? Handle(object request)
    {
        if (Player.GetInstance().Hp <= 0)
        {
            Player.GetInstance().Score = Player.GetInstance().Score + Player.GetInstance().Experience;
            if (Condition.Game.MidBossDone)
            {
                Player.GetInstance().Score = (float)Math.Round(Player.GetInstance().Score * 1.2);
            }
            Typing.WriteSlow("You died.");
            Typing.WriteSlow($"Your score is {Player.GetInstance().Score}");
            Condition.Game.Progress = false;
        }
        else
        {
            return base.Handle(request);
        }
        return null;
    }
}