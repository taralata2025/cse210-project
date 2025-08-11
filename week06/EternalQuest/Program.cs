using System;

class Program
{
    //  To show creativity and exceed requirements I added a gamified leveling system to the program.
    // The user's score determines their "level" (Novice, Apprentice, Journeyman, Master, Legend),
    // which is displayed along with their score on the main menu.
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}