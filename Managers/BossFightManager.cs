using DungeonCrawler.Characters;
using DungeonCrawler.Utilities;


namespace DungeonCrawler.Managers;

public class BossFightManager
{
    public static void BossEntrance(Boss boss)
    {
        if (boss.Level == 5)
        {
            Typing.WriteSlow("You entered big room with a mirror.\n" +
                             "As soon as you saw a reflection of yourself," +
                             " it crawled out of the mirror and rushed at you.");
        }
        else if (boss.Level == 10)
        {
            Typing.WriteSlow("You entered a huge space with a portal at the end." +
                             "The portal is guarded by a massive ancient dragon." +
                             " You will become dragon's meal,\nif you can't win.");
        }
    }

    public static void RunError(Boss boss)
    {
        if (boss.Level == 5)
        {
            Typing.WriteSlow("Door is locked, you can't run.");
        }
        else if (boss.Level == 10)
        {
            Typing.WriteSlow("It's no door here anymore, only dragon and portal.");
        }
    }

    public static void BossKilled(Boss boss)
    {
        if (boss.Level == 5)
        {
            Condition.Game.MidBossDone = true;
            BossReward();
        }
        else if (boss.Level == 10)
        {
            Condition.Game.EndBossDone = true;
        }
    }

    public static void BossAttack(Boss boss)
    {
        var rnd = new Random();
        var typeRandom = rnd.Next(1, 7);
        if (typeRandom == 1)
        {
            Fight.MagicAttack(Player.GetInstance(), boss);
        }
        else
        {
            Fight.Attack(boss, Player.GetInstance());
        }
    }

    public static void BossReward()
    {
        Player.GetInstance().Experience = 23700;
        Leveling.LevelUp();
        var rewardArmor = EquipmentManager
            .LoadArmor()
            .FirstOrDefault(x => x.Level == Player.GetInstance().Level);
        TreasureManager.ArmorQuestion(rewardArmor!);
        var randomWeapons =  EquipmentManager.LoadWeapon()
            .Where(x => x.Level == Player.GetInstance().Level)
            .ToArray();
        var rand = new Random();
        var rewardWeapon = randomWeapons[rand.Next(randomWeapons.Length)];
        TreasureManager.WeaponQuestion(rewardWeapon);
    }
}