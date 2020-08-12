using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Regex regex = new Regex(@"(?<surround>@|#)(?<word>[A-Za-z]{3,})\1\1(?<otherWord>[A-Za-z]{3,})\1");

        string input = Console.ReadLine();

        MatchCollection matches = regex.Matches(input);
        List<string> mirrors = new List<string>();
        foreach (Match match in matches)
        {
            string word = match.Groups["word"].Value;
            string otherWord = match.Groups["otherWord"].Value;
            StringBuilder sb = new StringBuilder();
            for (int i = otherWord.Length - 1; i >= 0; i--)
            {
                sb.Append(otherWord[i]);
            }
            string mirrorWord = sb.ToString();
            if (word == mirrorWord)
            {
                string mirror = word + " <=> " + otherWord;
                mirrors.Add(mirror);
            }
        }
        if (matches.Count == 0)
        {
            Console.WriteLine("No word pairs found!");
        }
        else
        {
            Console.WriteLine($"{matches.Count} word pairs found!");
        }
        if (mirrors.Count == 0)
        {
            Console.WriteLine("No mirror words!");
        }
        else
        {
            Console.WriteLine("The mirror words are:");
            Console.WriteLine(string.Join(", ", mirrors));
        }
    }
}

