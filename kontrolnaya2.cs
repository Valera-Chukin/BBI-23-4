using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public static string Task2(string input)
    {
        string[] words = input.Split(new char[] { ' ', ',', '.', '!', '?', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> wordCounts = new Dictionary<string, int>();

        foreach (string word in words)
        {
            string cleanedWord = word.ToLower();
            if (wordCounts.ContainsKey(cleanedWord))
            {
                wordCounts[cleanedWord]++;
            }
            else
            {
                wordCounts[cleanedWord] = 1;
            }
        }

        List<string> repeatedWords = wordCounts.Where(pair => pair.Value > 1).Select(pair => pair.Key).ToList();

        return string.Join(" ",repeatedWords);
    }
    public static void Main()
    {
        string text = Console.ReadLine();
        string[] arr = new[] { Task1(text), Task2(text) };
    }
    public static string Task1(string text)
    {
        var sentences = text.Split('.', '!', '?')
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(s => s.Trim())
            .ToList();

        var minLength = int.MaxValue;
        var shortestSentence = "";

        foreach (var sentence in sentences)
        {
            if (sentence.Length < minLength)
            {
                minLength = sentence.Length;
                shortestSentence = sentence;
            }
        }

        return shortestSentence;
    }

}
