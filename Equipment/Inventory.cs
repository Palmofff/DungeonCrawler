using DungeonCrawler.Characters;
using DungeonCrawler.Utilities;

namespace DungeonCrawler.Equipment;

public class Inventory
{
    private static string[] _actionList = new[] { "remove", "equip", "close" };
    public static List<InventoryItem> Items = new List<InventoryItem>();

    public static void ShowItems()
    {
        Typing.WriteSlow("Inventory:");
        for (int i = 0; i < Items.Count; i++)
        {
            Typing.WriteSlow($"{i+1}. {Items[i].Name}");
        }
        Typing.WriteSlow($"Healing potions: {Potions.GetPotion().Quantity}");
    }

    public static void AddToInventory(InventoryItem item)
    {
        Items.Add(item);
        Typing.WriteSlow($"{item.Name} added to inventory.");
    }

    public static void RemoveFromInventory(int index)
    {
        Typing.WriteSlow($"{Items[index].Name} removed from inventory.");
        Items.RemoveAt(index);
    }

    public static void Equip(InventoryItem item)
    {
        switch (item)
        {
            case Armor armor:
                Player.GetInstance().Armor = armor;
                Player.GetInstance().Ac = armor.Ac + Player.GetInstance().Race.Ac;
                Typing.WriteSlow($"You equipped {Player.GetInstance().Armor.Name}, " +
                                 $"your AC is {Player.GetInstance().Ac}");
                break;
            
            case Weapon weapon:
                Player.GetInstance().Weapon = weapon;
                Player.GetInstance().AttackBonus = weapon.AttackBonus +
                                                   Player.GetInstance().Race.AttackBonus;
                Player.GetInstance().Damage = weapon.Damage;
                Typing.WriteSlow($"You equipped {Player.GetInstance().Weapon.Name}.");
                Typing.WriteSlow($"Your attack bonus is: {Player.GetInstance().AttackBonus}.");
                Typing.WriteSlow($"You damage is {Player.GetInstance().Damage![0]}d{Player.GetInstance().Damage![1]}+" +
                                 $"{Player.GetInstance().Damage![2]}.");
                break;
        }

        Items.Remove(item);
    }

    

    private static int ParseNumber()
    {
        var itemInput  = Console.ReadLine();
        while (!itemInput!.All(char.IsDigit))
        {
            Typing.WriteSlow("Error, type only numbers!");
            itemInput  = Console.ReadLine();
        }

        return Convert.ToInt32(itemInput);
    }

    private static int ItemNumber(int parsed)
    {
        while (parsed<0 || parsed>Items.Count)
        {
            Typing.WriteSlow("Error, your number is not number of item.");
            parsed = ParseNumber();
            
        }
        return parsed - 1;
    }
    public static void InventoryMenu()
    {
        ShowItems();
        Typing.WriteSlow("Choose action with inventory:remove or equip?");
        Typing.WriteSlow("If you want to close this menu select: close.");
        var menuAction = Console.ReadLine();
        while (!_actionList.Contains(menuAction))
        {
            Typing.WriteSlow("Error, only: close, equip and remove.");
            menuAction = Console.ReadLine();
        }

        if (menuAction == "remove")
        {
            Typing.WriteSlow($"Type number of item you want to {menuAction}");
            RemoveFromInventory(ItemNumber(ParseNumber()));
        }
        else if (menuAction == "equip")
        {
            Typing.WriteSlow($"Type number of item you want to {menuAction}");
            Equip(Items[ItemNumber(ParseNumber())]);
        }

    }
    
    
}