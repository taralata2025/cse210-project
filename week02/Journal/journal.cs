using System;
using System.Collections.Generic;
using System.IO; 

public class Journal
{
    public List<Entry> Entries { get; private set; }
    private List<string> _prompts;
    private Random _random;

    public Journal()
    {
        Entries = new List<Entry>();
        _random = new Random();
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What is one thing you learned today?", 
            "What are you grateful for right now?" 
        };
    }

    public void WriteNewEntry()
    {
        string randomPrompt = GetRandomPrompt();
        Console.WriteLine(randomPrompt);
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); 
        Entry newEntry = new Entry(currentDate, randomPrompt, response);
        Entries.Add(newEntry);
        Console.WriteLine("Entry saved!\n");
    }

    public void DisplayJournal()
    {
        if (Entries.Count == 0)
        {
            Console.WriteLine("Journal is empty. Write some entries first!\n");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---");
        foreach (Entry entry in Entries)
        {
            entry.Display();
        }
        Console.WriteLine("--- End of Journal ---\n");
    }

    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Entry entry in Entries)
                {
                    outputFile.WriteLine(entry.ToFileString());
                }
            }
            Console.WriteLine($"Journal saved to {filename}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}\n");
        }
    }

    public void LoadFromFile(string filename)
    {
        Entries.Clear(); // 
        try
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                Entry entry = Entry.FromFileString(line);
                if (entry != null)
                {
                    Entries.Add(entry);
                }
            }
            Console.WriteLine($"Journal loaded from {filename}\n");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File '{filename}' not found. Please check the filename and path.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}\n");
        }
    }

    private string GetRandomPrompt()
    {
        int index = _random.Next(0, _prompts.Count);
        return _prompts[index];
    }
}