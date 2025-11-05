using OfflineDictionary.Logic;
namespace OfflineDictionary;
internal class Program
{
    static void Main(string[] args)
    {
        string[] words = GetWords.Run("OfflineDictionary.words.txt", 370105);
        string input = string.Empty;
        while (true)
        {
            Console.Clear();
            for (int i = 0; i < words.Length && input != string.Empty; ++i)
            {
                if (words[i].StartsWith(input)) Console.WriteLine(words[i]);
            }
            Console.WriteLine(Environment.NewLine + "Enter The Beginning Of A Word:");
            input = Console.ReadLine()!;
        }
    }
}
