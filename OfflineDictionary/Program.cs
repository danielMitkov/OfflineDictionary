using OfflineDictionary.Logic;
namespace OfflineDictionary;
internal class Program
{
    static void Main(string[] args)
    {
        string[] words = GetWords.Run("OfflineDictionary.words.txt", 370105);

        while (true)
        {
            Console.WriteLine(Environment.NewLine + "Enter The Beginning Of A Word:");

            string input = Console.ReadLine()!;
            if (input == string.Empty) continue;
            input = input.ToLower();

            List<string> results = new();

            for (int i = 0; i < words.Length; ++i)
            {
                bool isMatch = IsMatching(words[i], input);

                if (isMatch) results.Add(words[i]);
            }

            List<List<string>> columnsResults = new();
            columnsResults.Add(new List<string>());
            columnsResults.Add(new List<string>());
            columnsResults.Add(new List<string>());
            columnsResults.Add(new List<string>());
            columnsResults.Add(new List<string>());

            int resultI = 0;
            int columnSize = (int)Math.Ceiling(results.Count / (decimal)columnsResults.Count);

            for (int listI = 0; listI < columnsResults.Count; ++listI)
            {
                for (int count = columnSize; count > 0; --count)
                {
                    if (resultI >= results.Count) break;

                    columnsResults[listI].Add(results[resultI++]);
                }
            }

            Console.WriteLine($"Results For \"{input}\":");

            for (int columnI = 0; columnI < columnSize; ++columnI)
            {
                for (int listI = 0; listI < columnsResults.Count; ++listI)
                {
                    if (columnI >= columnsResults[listI].Count) break;

                    int spacesCount = 32;// max length word + 1
                    spacesCount -= columnsResults[listI][columnI].Length;

                    string spaces = new string(Enumerable.Repeat(' ', spacesCount).ToArray());
                    spaces = listI == columnsResults.Count - 1 ? string.Empty : spaces;// if last column -> no spaces

                    Console.Write($"{columnsResults[listI][columnI]}{spaces}");
                }
                Console.WriteLine();
            }
        }
    }

    private static bool IsMatching(string word, string target)
    {
        bool isMatch = true;

        for (int c = 0; c < target.Length; ++c)
        {
            if (word.Length < target.Length || word[c] != target[c])
            {
                isMatch = false;
                break;
            }
        }

        return isMatch;
    }
}
