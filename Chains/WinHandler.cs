using DungeonCrawler.Characters;
using DungeonCrawler.Utilities;

namespace DungeonCrawler.Chains;

public class WinHandler : AbstractHandler
{
    public override object? Handle(object request)
    {
        Player.GetInstance().Score += Player.GetInstance().Experience;
        if (Condition.Game.EndBossDone)
        {
            if (Condition.Game.MidBossDone)
            {
                Player.GetInstance().Score = (float)Math.Round(Player.GetInstance().Score * 1.2);
            }
            Player.GetInstance().Score = (float)Math.Round(Player.GetInstance().Score * 1.5);
            Typing.WriteSlow("You finished this game!Congratulations!");
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