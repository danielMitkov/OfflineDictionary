using System.Reflection;
namespace OfflineDictionary.Logic;
internal static class GetWords
{
    internal static string[] Run(string internalPath, int size)
    {
        using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(internalPath);
        using StreamReader reader = new StreamReader(stream);
        int i = 0;
        string[] words = new string[size];
        string line;
        while ((line = reader.ReadLine()) != null) words[i++] = line;
        return words;
    }
}
