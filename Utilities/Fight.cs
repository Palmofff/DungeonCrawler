using DungeonCrawler.Characters;
using DungeonCrawler.Equipment;
using DungeonCrawler.Managers;

namespace DungeonCrawler.Utilities;

public abstract class Fight
{
    private static List<string> _fightAction = new List<string>() { "run", "fight", "heal" };
    public static void Attack(Character atacker, Character atacked)
    {
        Random rand = new Random();
        int attackDice = rand.Next(1, 21);
        bool isCrit = (attackDice == 20);
        if (attackDice + (int)atacker.AttackBonus >= (int)atacked.Ac)
        {
            var damage = RollDamage(atacker.Damage![0],
                atacker.Damage[1],
                atacker.Damage[2]);
            if (isCrit)
            {
                damage *= 2;
                Typing.WriteSlow("Critical attack!");
            }

            if (damage >= (int)atacked.Hp)
            {
                damage = (int)atacked.Hp;
            }

            atacked.Hp -= damage;
            if (atacker == Player.GetInstance())
            {
                Player.GetInstance().Score += damage;
            }
            else
            {
                Player.GetInstance().Score -= damage;
            }
            Typing.WriteSlow($"{atacker.Name} dealt {damage} to {atacked.Name}");
            Typing.WriteSlow($"{atacked.Name} hp is {atacked.Hp}/{atacked.MaxHp}");
        }
        else
        {
            Typing.WriteSlow($"{atacker.Name} missed.");
        }
    }

    public static void MagicAttack(Player player, Boss boss)
    {
        Random rand = new Random();
        int attackDice = rand.Next(1, 21);
        bool isCrit = (attackDice == 20);
        if (attackDice + (int)boss.AttackBonus >= (int)player.Ac)
        {
            int damage = RollDamage(boss.Damage![0],
                boss.Damage[1],
                boss.Damage[2]);
            if (isCrit)
            {
                damage *= 2;
                Typing.WriteSlow("Critical magic attack!");
            }

            player.Hp -= damage;
            player.Score -= damage;
            if (boss.Level == 10)
            {
                Typing.WriteSlow($"{boss.Name} set to fire {player.Name} with fire breath " +
                                 $"and dealt {damage} damage! ");
            }
            else if (boss.Level == 5)
                Typing.WriteSlow($"{boss.Name} conjured illusion mirrors with {player.Name} " +
                                 $"reflections that attacked {player.Name} and dealt {damage} damage.");
        }
        else
        {
            Typing.WriteSlow($"{boss.Name}'s magic attack missed.");
        }
    }


    private static int RollDamage(int diceCount, int diceValue, int damageBonus)
    {
        Random random = new Random();
        List<int> diceResults = new List<int>();

        for (int i = 0; i < diceCount; i++)
        {
            diceResults.Add(random.Next(1, diceValue + 1));
        }

        return diceResults.Sum() + damageBonus;
    }

    private static void Heal()
    {
        if (Potions.GetPotion().Quantity > 0)
        {
            var healMax = Player.GetInstance().MaxHp - Player.GetInstance().Hp;
            switch (healMax)
            {
                case>0:
                    Potions.GetPotion().Quantity -= 1;
                    Player.GetInstance().Hp += (float)(Math.Round(0.3*Player.GetInstance().MaxHp)
                                                       + Player.GetInstance().Level);
                    if (Player.GetInstance().Hp > Player.GetInstance().MaxHp)
                    {
                        Player.GetInstance().Hp = Player.GetInstance().MaxHp;
                    }
                    Typing.WriteSlow("You used healing potion, your HP is " +
                                     $"{Player.GetInstance().Hp}/{Player.GetInstance().MaxHp}");
                    break;
                case 0:
                    Typing.WriteSlow("Your HP is full, no need to use potion.");
                    break;
            }
            
            
                
        }
        else
        {
            Typing.WriteSlow("You have no potions!");
        }
    }


    public static void Combat(Monster monster)
    {
        Typing.WriteSlow($"Your opponent is {monster.Name}, level: {monster.Level}");
        while (Player.GetInstance().Hp > 0 && monster.Hp > 0)
        {
            Typing.WriteSlow("You want to fight, run or heal?");
            var action = Console.ReadLine();
            while (!_fightAction.Contains(action!))
            {
                Typing.WriteSlow("Error! Choose only from fight, or run!");
                action = Console.ReadLine();
            }

            if (action == "run")
            {
                break;
            }
            else if (action == "heal")
            {
                Heal();
            }
            else if (action == "fight")
            {
                if (Player.GetInstance().Hp > 0 && monster.Hp > 0)
                {
                    Attack(Player.GetInstance(), monster);
                    if (monster.Hp <= 0)
                    {
                        Typing.WriteSlow($"You killed {monster.Name} and gained {monster.Experience}");
                        Player.GetInstance().Experience += monster.Experience;
                        Typing.WriteSlow($"Your experience is {Player.GetInstance().Experience}");
                    }
                }

                if (Player.GetInstance().Hp > 0 && monster.Hp > 0)
                {
                    Attack(monster, Player.GetInstance());
                }
            }
        }
    }

    public static void Combat(Boss boss)
    {
        BossFightManager.BossEntrance(boss);
        while (Player.GetInstance().Hp > 0 && boss.Hp > 0)
        {
            Typing.WriteSlow("You want to fight, heal or run?");
            var action = Console.ReadLine();
            while (!_fightAction.Contains(action!))
            {
                Typing.WriteSlow("Error! Choose only from fight, heal or run!");
                action = Console.ReadLine();
            }

            if (action == "run")
            {
                BossFightManager.RunError(boss);
            }
            else if (action == "heal")
            {
                Heal();
            }
            else
            {
                if (Player.GetInstance().Hp > 0 && boss.Hp > 0)
                {
                    Attack(Player.GetInstance(), boss);
                }
                if (Player.GetInstance().Hp > 0 && boss.Hp > 0)
                {
                    BossFightManager.BossAttack(boss);
                }
                
            }
        }
        if (boss.Hp <= 0)
        {
            BossFightManager.BossKilled(boss);
        }
    }
}