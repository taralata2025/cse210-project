// Program.cs
using System;
using System.Collections.Generic; 

class Program
{
    // To exceed requirement i included a static dictionary to store the count of how many times each activity has been performed in the program.
    private static Dictionary<string, int> _activityCounts = new Dictionary<string, int>()
    {
        { "Breathing Activity", 0 },
        { "Reflection Activity", 0 },
        { "Listing Activity", 0 }
    };

    static void Main(string[] args)
    {
        string choice = "";
 
        do
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. View activity log");
            Console.WriteLine("  5. Quit"); 
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine();
            Console.WriteLine();

            string selectedActivityName = "";

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.DisplayStartingMessage();
                    breathingActivity.Run();
                    breathingActivity.DisplayEndingMessage();
                    selectedActivityName = "Breathing Activity"; 
                    break;
                case "2":
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.DisplayStartingMessage();
                    reflectingActivity.Run();
                    reflectingActivity.DisplayEndingMessage();
                    selectedActivityName = "Reflection Activity"; 
                    break;
                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.DisplayStartingMessage();
                    listingActivity.Run();
                    listingActivity.DisplayEndingMessage();
                    selectedActivityName = "Listing Activity"; 
                    break;
                case "4":
                    DisplayActivityLog(); 
                    break;
                case "5": 
                    Console.WriteLine("Exiting program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    System.Threading.Thread.Sleep(2000);
                    break;
            }

            if (!string.IsNullOrEmpty(selectedActivityName))
            {
                _activityCounts[selectedActivityName]++;
            }

        } while (choice != "5"); 
    }

    static void DisplayActivityLog()
    {
        Console.Clear();
        Console.WriteLine("--- Activity Completion Log ---");
        Console.WriteLine();
        foreach (var entry in _activityCounts)
        {
            Console.WriteLine($"- {entry.Key}: {entry.Value} time(s)");
        }
        Console.WriteLine();
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey(); 
    }
}