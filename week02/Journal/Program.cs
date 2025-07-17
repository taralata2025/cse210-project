using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Exceeding Requirements: Added a custom prompt list in Journal.cs (see Journal.cs for details)
       

        Journal myJournal = new Journal();
        bool running = true;

        Console.WriteLine("Welcome to the Journal Program!");

        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    myJournal.WriteNewEntry();
                    break;
                case "2":
                    myJournal.DisplayJournal();
                    break;
                case "3":
                    Console.Write("Enter filename to save (e.g., myjournal.txt): ");
                    string saveFilename = Console.ReadLine();
                    myJournal.SaveToFile(saveFilename);
                    break;
                case "4":
                    Console.Write("Enter filename to load (e.g., myjournal.txt): ");
                    string loadFilename = Console.ReadLine();
                    myJournal.LoadFromFile(loadFilename);
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Thank you for using the Journal Program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal to a file");
        Console.WriteLine("4. Load the journal from a file");
        Console.WriteLine("5. Exit");
        Console.Write("What would you like to do? ");
    }
}