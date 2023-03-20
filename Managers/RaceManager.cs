using System.Text.Json;
using DungeonCrawler.Races;

namespace DungeonCrawler.Managers;


public class RaceManager
{
    public static Race[] LoadRaces()
    {
        var fileName = @"..\..\..\serializables\Race.json";
        var jsonString = File.ReadAllText(fileName);
        var races = JsonSerializer.Deserialize<Race[]>(jsonString);
        return races!;
    }
    
}
