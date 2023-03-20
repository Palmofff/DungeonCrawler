using DungeonCrawler.Characters;
using DungeonCrawler.Equipment;
using DungeonCrawler.Managers;
using DungeonCrawler.Utilities;

namespace DungeonCrawler.Chains;

public class LabyrinthHandler : AbstractHandler
{
    private static List<string> _labChoice = new List<string>() { "left", "right", "straight",
        "stats", "inv" };
    public override object? Handle(object request)
    {
        Typing.WriteSlow("You can see three tunnel branch: left, straight and right. " +
                         "Where you want to go?");
        Typing.WriteSlow("You can check your stats by typing: stats and you can check your " +
                         "inventory by typing: inv.");
        var way = Console.ReadLine();
        while (!_labChoice.Contains(way!))
        {
            Typing.WriteSlow("Error, choose only from left, straight, right, inv, or stats:");
            way = Console.ReadLine();
        }
        switch (way)
        {
            case"right":
                LabManager.RightWay();
                break;
            case"straight":
                LabManager.StraightWay();
                break;
            case"left":
                LabManager.LeftWay();
                break;
            case"inv":
                Inventory.InventoryMenu();
                break;
            case"stats":
                Player.ShowStats();
                break;
                
        }
        return base.Handle(request);
    }
}