using System;
using System.Linq;
using System.Reflection;
using System.Text;

class Program
{
    static void Main()
    {
        string message = Console.ReadLine();

        string input = "";
        while ((input = Console.ReadLine()) != "Reveal")
        {
            string[] tokens = input.Split(":|:", StringSplitOptions.RemoveEmptyEntries);

            string command = tokens[0];
            switch (command)
            {
                case "InsertSpace":
                    int index = int.Parse(tokens[1]);
                    message = message.Insert(index, " ");
                    Console.WriteLine(message);
                    break;
                case "Reverse":
                    string substring = tokens[1];
                    StringBuilder sb = new StringBuilder();
                    if (message.Contains(substring))
                    {
                        index = message.IndexOf(substring);
                        message = message.Remove(index, substring.Length);
                        for (int i = substring.Length - 1; i >= 0; i--)
                        {
                            sb.Append(substring[i]);
                        }
                        substring = sb.ToString();
                        message += substring;
                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                case "ChangeAll":
                    substring = tokens[1];
                    string replacement = tokens[2];
                    message = message.Replace(substring, replacement);
                    Console.WriteLine(message);
                    break;
            }
        }
        Console.WriteLine($"You have a new text message: {message}");
    }
}

