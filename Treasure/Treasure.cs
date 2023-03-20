using System.Diagnostics;
using DungeonCrawler.Characters;
using DungeonCrawler.Equipment;
using DungeonCrawler.Managers;
using DungeonCrawler.Utilities;

namespace DungeonCrawler.Treasure;

public class Treasure
{
    public static void Chest()
    {
        var rand = new Random();
        var chestIndex = rand.Next(4);

        InventoryItem randomItem = null!;
        if (chestIndex == 0)
        {
            randomItem = TreasureManager.ArmorByLevel();
            TreasureManager.ArmorQuestion((Armor)randomItem);
            
        }
        else if (chestIndex == 1)
        {
            randomItem = TreasureManager.WeaponByLevel();
            TreasureManager.WeaponQuestion((Weapon)randomItem);
        }
        else
        {
            var potions = rand.Next(1,4);
            Typing.WriteSlow($"You found {potions} potion(s)!");
            Potions.GetPotion().Quantity += potions;
            
        }
    }

    
}