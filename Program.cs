using DungeonCrawler.Chains;
using DungeonCrawler.Utilities;


var death = new DeathHandler();
var lab = new LabyrinthHandler();
var levels = new LevelsHandler();
var win = new WinHandler();
var dragonBoss = new DragonHandler();
var midBoss = new MidBossHandler();

death.SetNext(win).SetNext(levels).SetNext(dragonBoss).SetNext(midBoss).SetNext(lab);

Condition.GameStarting();

while (Condition.Game.Progress)
{
    Chain.Chained(death);
}   