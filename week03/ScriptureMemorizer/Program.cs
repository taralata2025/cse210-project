
using System;
using System.Collections.Generic; 
using System.IO;                  
using System.Linq;                
using System.Text.RegularExpressions;

//To exceed Requirements the program chooses scriptures at random that loads from a library of scriptures on a txt file

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptureLibrary = LoadScripturesFromFile("scriptures.txt");

        if (scriptureLibrary.Count == 0)
        {
            Console.WriteLine("No scriptures found in the library. Please add entries to 'scriptures.txt'.");
            return;
        }

        Random random = new Random();
        Scripture currentScripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];

        bool running = true;
        while (running)
        {
            Console.Clear(); 
            Console.WriteLine(currentScripture.GetDisplayText()); 

            if (currentScripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words are hidden for this scripture. Press Enter to choose another, or type 'quit' to finish.");
                string finalInput = Console.ReadLine();
                if (finalInput.ToLower() == "quit")
                {
                    running = false; 
                }
                else
                {
                    currentScripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];
                }
                continue; 
            }

            Console.WriteLine("\nPress Enter to hide words or type 'quit' to finish:");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
            {
                running = false; 
            }
            else
            {
                currentScripture.HideRandomWords(3);
            }
        }

        Console.WriteLine("Goodbye!");
    }

    static List<Scripture> LoadScripturesFromFile(string filename)
    {
        List<Scripture> scriptures = new List<Scripture>();
        try
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split('~', 2); 

                if (parts.Length == 2)
                {
                    string referenceString = parts[0].Trim();
                    string scriptureText = parts[1].Trim();

                    Reference parsedReference = ParseReferenceString(referenceString);
                    if (parsedReference != null)
                    {
                        scriptures.Add(new Scripture(parsedReference, scriptureText));
                    }
                    else
                    {
                        Console.WriteLine($"Warning: Could not parse reference string '{referenceString}'. Skipping line.");
                    }
                }
                else
                {
                    Console.WriteLine($"Warning: Malformed line in '{filename}': {line}. Skipping.");
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: Scripture library file '{filename}' not found. Please create it.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading scriptures: {ex.Message}");
        }
        return scriptures;
    }

    static Reference ParseReferenceString(string refString)
    {

        Match match = Regex.Match(refString, @"^(?<book>[A-Za-z0-9 ]+)\s+(?<chapter>\d+):(?<startVerse>\d+)(?:-(?<endVerse>\d+))?$");

        if (match.Success)
        {
            string book = match.Groups["book"].Value.Trim();
            int chapter = int.Parse(match.Groups["chapter"].Value);
            int startVerse = int.Parse(match.Groups["startVerse"].Value);

            if (match.Groups["endVerse"].Success)
            {
                int endVerse = int.Parse(match.Groups["endVerse"].Value);
                return new Reference(book, chapter, startVerse, endVerse);
            }
            else
            {
                return new Reference(book, chapter, startVerse);
            }
        }
        return null;
    }
}