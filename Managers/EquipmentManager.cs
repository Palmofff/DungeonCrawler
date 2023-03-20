using System.Text.Json;
using DungeonCrawler.Equipment;

namespace DungeonCrawler.Managers;


public class EquipmentManager
{
    public static Armor[] LoadArmor()
    {
        var fileName = @"..\..\..\serializables\Armor.json"; 
        var jsonString = File.ReadAllText(fileName); 
        var armors = JsonSerializer.Deserialize<Armor[]>(jsonString);
        return armors!;
    }

    public static Weapon[] LoadWeapon()
    {
        var fileName = @"..\..\..\serializables\Weapon.json"; 
        var jsonString = File.ReadAllText(fileName); 
        var weapons = JsonSerializer.Deserialize<Weapon[]>(jsonString);
        return weapons!;
    }
}




