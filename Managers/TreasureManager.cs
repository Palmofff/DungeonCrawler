using System.Net.Sockets;
using DungeonCrawler.Characters;
using DungeonCrawler.Equipment;
using DungeonCrawler.Utilities;

namespace DungeonCrawler.Managers;

public class TreasureManager
{
    private static List<string> _answers = new List<string>(){"equip", "inv", "throw"};
    public static Weapon WeaponByLevel()
    {
        var loadedWeapons = EquipmentManager.LoadWeapon()
            .Where(x => x.Level <= Player.GetInstance().Level)
            .ToArray();
        var rand = new Random();
        var randomWeapon = loadedWeapons[rand.Next(loadedWeapons.Length)];
        return randomWeapon;
    }
    public static Armor ArmorByLevel()
    {
        var loadedArmors = EquipmentManager.LoadArmor()
            .Where(x => x.Level <= Player.GetInstance().Level)
            .ToArray();
        var rand = new Random();
        var randomArmor = loadedArmors[rand.Next(loadedArmors.Length)];
        return randomArmor;
    }

    public static void ArmorQuestion(Armor item)
    {
        Typing.WriteSlow($"You get {item.Name}.Level: {item.Level},AC: {item.Ac}.");
        Typing.WriteSlow($"Do you want to equip {item.Name}(your previous" +
                         $" equipment will be deleted), or add to inventory? ");
        Typing.WriteSlow($"Your old armor is {Player.GetInstance().Armor.Name}.");
        Typing.WriteSlow($"Your old armor's AC is {Player.GetInstance().Armor.Ac}");
        Typing.WriteSlow("Type equip, throw or inv:");
        var answer = Console.ReadLine();
        while (!_answers.Contains(answer!))
        {
            Typing.WriteSlow("Error! Type equip, throw or inv.");
            answer = Console.ReadLine();
        }

        switch (answer)
        {
            case "equip":
                Player.GetInstance().Armor = item;
                Player.GetInstance().Ac = item.Ac + Player.GetInstance().Race.Ac;
                break;
            case "inv":
                Inventory.AddToInventory(item);
                break;
            case"throw":
                break;
        }
    }
    public static void WeaponQuestion(Weapon item)
    {
        Typing.WriteSlow($"You get {item.Name}.Level: {item.Level}," +
                         $" AttackBonus:{item.AttackBonus}," +
                         $"Damage: {item.Damage![0]}d{item.Damage![1]}+{item.Damage![2]}");
        Typing.WriteSlow($"Do you want to equip {item.Name}(your previous" +
                         $" equipment will be deleted), or add to inventory? ");
        Typing.WriteSlow($"Your old weapon is {Player.GetInstance().Weapon.Name}.");
        Typing.WriteSlow($"Attack bonus of old weapon: {Player.GetInstance().Weapon.AttackBonus}," +
                         $"Damage:{Player.GetInstance().Damage![0]}d{Player.GetInstance().Damage![1]}" +
                         $"+{Player.GetInstance().Damage![2]}");
        Typing.WriteSlow("Type equip, throw or inv.");
        
        var answer = Console.ReadLine();
        while (!_answers.Contains(answer!))
        {
            Typing.WriteSlow("Error! Type equip, throw or inv.");
            answer = Console.ReadLine();
        }

        switch (answer)
        {
            case "equip":
                Player.GetInstance().Weapon = item;
                Player.GetInstance().Ac = item.AttackBonus + Player.GetInstance().Race.AttackBonus;
                Player.GetInstance().Damage = item.Damage;
                break;
            case "inv":
                Inventory.AddToInventory(item);
                break;
            case"throw":
                break;
        }
    }
}