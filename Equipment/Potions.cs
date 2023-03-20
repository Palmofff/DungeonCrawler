namespace DungeonCrawler.Equipment;

public sealed class Potions
{
    public int Quantity { get; set; }
    
    private Potions() {  }

    private static Potions potion;

    
    public static Potions GetPotion()
    {
        if (potion == null)
        {
            potion = new Potions();
            potion.Quantity = 0;
        }
        return potion;
    }
    

}