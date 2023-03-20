

namespace DungeonCrawler.Utilities
{
    public abstract class Typing

    {
        public static void WriteSlow(string text)
        {
            for (var i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                Thread.Sleep(15);
            }
            Console.WriteLine();
        }
    
    }
}
