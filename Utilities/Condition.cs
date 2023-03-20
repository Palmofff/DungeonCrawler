namespace DungeonCrawler.Utilities;

public class Condition
{
    public double DifficultyMultiplier { get; set; }
    public bool MidBossDone { get; set; }
    public bool EndBossDone { get; set; }
    public bool Progress { get; set; }
    public bool MidBossSkipped { get; set; }
    

    public static Condition Game = new Condition();
    
    public static void GameStarting()
    {
        Game.DifficultyMultiplier = 1;
        Game.MidBossDone = false;
        Game.EndBossDone = false;
        Game.Progress = true;
        Game.MidBossSkipped = false;
    }

    
    
}