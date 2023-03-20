using DungeonCrawler.Equipment;
using DungeonCrawler.Managers;
using DungeonCrawler.Races;
using DungeonCrawler.Utilities;
namespace DungeonCrawler.Characters

    {
   
    public sealed class Player: Character
    {
        public Race Race { get; set; }
        public float Score { get; set; }
        public Armor Armor { get; set; }
        public Weapon Weapon { get; set; }
        private Player() {  }

        
        private static Player player;

        private static void CreateCharacter()
        {
            player = new Player();
            Typing.WriteSlow("Give a name to your char:");
            player.Name = Console.ReadLine();
            player.Level = 1;
            player.Experience = 0;
            player.Score = 0;
            Typing.WriteSlow("You can choose a race from this list: human, elf, dwarf, orc.");
            var raceNames = RaceManager
                .LoadRaces()
                .Select(x=>x.Name)
                .ToArray()!;
            var raceInput = Console.ReadLine()!;
            while (!raceNames.Contains(raceInput!))
            {
                Typing.WriteSlow("Error, choose race only from list given below!");
                raceInput = Console.ReadLine();
            }

            player.Race = RaceManager
                .LoadRaces()
                .Where(x => x.Name == raceInput)!
                .FirstOrDefault()!;
            
            player.Armor = EquipmentManager
                .LoadArmor()!
                .Where(x => x.Name == "leather armor")!
                .FirstOrDefault()!;
            player.Ac = player.Race.Ac + player.Armor.Ac;
            Typing.WriteSlow($"Your starting armor is {player.Armor.Name}.");
            Typing.WriteSlow("You can choose your starting weapon from this list:" +
                             "battleaxe, scimitar, sickle:");

            var startingWeapons = EquipmentManager
                .LoadWeapon()!
                .Where(x => x.Level <= player.Level)
                .Select(x=>x.Name)
                .ToArray();
            var weaponChoice = Console.ReadLine();
            while (!startingWeapons.Contains(weaponChoice!))
            {
                Typing.WriteSlow("Error! Choose only from list given  below!");
                Typing.WriteSlow("You can choose your starting weapon from this list:" +
                                 "battleaxe, scimitar, sickle:");
                weaponChoice = Console.ReadLine();
            }

            player.Weapon = EquipmentManager
                .LoadWeapon()
                .Where(x => x.Name == weaponChoice)!
                .FirstOrDefault()!;
            Typing.WriteSlow($"Your starting weapon is {player.Weapon.Name}");
            player.Damage = player.Weapon.Damage;
            player.AttackBonus = player.Weapon.AttackBonus + player.Race.AttackBonus;
            Random rnd = new Random();
            player.MaxHp = rnd.Next(11, 19);
            player.Hp = player.MaxHp;
            Player.ShowStats();
        }
       
        public static Player GetInstance()
        {
            if (player == null)
                CreateCharacter();
            
            return player;
        }

        public static void ShowStats()
        {
            Typing.WriteSlow($"Name: {player.Name}\n" +
                             $"Level: {player.Level}\n" +
                             $"Weapon: {player.Weapon.Name}\n" +
                             $"Armor: {player.Armor.Name}\n" +
                             $"Armor Class: {player.Ac}\n" +
                             $"Attack Bonus: {player.AttackBonus}\n" +
                             $"Damage: {player.Damage![0]}d{player.Damage[1]}+{player.Damage[2]}\n" +
                             $"HP: {player.Hp}/{player.MaxHp}\n" +
                             $"Experience: {player.Experience}");
        }

        
    }
}