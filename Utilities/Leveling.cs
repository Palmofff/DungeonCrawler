using DungeonCrawler.Characters;

namespace DungeonCrawler.Utilities;

public class Leveling

{
    private static int DiceHp(int diceCount, int diceValue)
    {
        Random random = new Random();
        List<int> diceResults = new List<int>();

        for (int i = 0; i < diceCount; i++)
        {
            diceResults.Add(random.Next(1, diceValue + 1));
        }

        return diceResults.Sum();
    }

    public static void LevelUp()
    {
        var newLevel = Player.GetInstance().Level;
        var levelUp = false;
        switch ((Player.GetInstance().Level, Player.GetInstance().Experience))
        {
            case(<10, >=68900):
                newLevel = 10;
                levelUp = true;
                break;
            case(<9, >=48200):
                newLevel = 9;
                levelUp = true;
                break;
            case(<8, >=35000):
                newLevel = 8;
                levelUp = true;
                break;
            case(<7, >=23600):
                newLevel = 7;
                levelUp = true;
                break;
            case(<6, >=14600):
                newLevel = 6;
                levelUp = true;
                break;
            case(<5, >=7100):
                newLevel = 5;
                levelUp = true;
                break;
            case(<4, >=3500):
                newLevel = 4;
                levelUp = true;
                break;
            case(<3, >=1700):
                newLevel = 3;
                levelUp = true;
                break;
            case(<2, >=500):
                newLevel = 2;
                levelUp = true;
                break;
        }
        if (levelUp)
        {
            Player.GetInstance().MaxHp += DiceHp((newLevel - Player.GetInstance().Level),
                10);
            Player.GetInstance().Hp = Player.GetInstance().MaxHp;
            Player.GetInstance().Level = newLevel;
            Typing.WriteSlow($"Lvl up! Your lvl is {Player.GetInstance().Level}.");
            Player.ShowStats();
        }
    }
}  