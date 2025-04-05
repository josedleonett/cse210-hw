using System;

class Program
{
    static void Main(string[] args)
    {
        //    Creativity and Exceeds Core Requirements:
        // 1. Session Tracking
        // 2. Grouped Activity Summaries
        // 3. Detailed Activity Summaries
        

        Session session = new Session();
        session.StartSession();

        List<string> menuOptions = new List<string>
        {
            "1. Start Breathing Activity",
            "2. Start Reflecting Activity",
            "3. Start Listing Activity",
            "4. End session"
        };

        static void DisplayMenu(List<string> menuOptions, Session session)
        {
            Console.Clear();
            Console.WriteLine("MENU OPTIONS:");
            foreach (string option in menuOptions)
            {
                Console.WriteLine(option);
            }
            Console.Write("Select a choice from the menu: ");
            string userInput = Console.ReadLine();
            int choice = int.Parse(userInput);

            switch (choice)
            {
                case 1:
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                    session.AddActivity(breathingActivity);
                    break;
                case 2:
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.Run();
                    session.AddActivity(reflectingActivity);
                    break;
                case 3:
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();
                    session.AddActivity(listingActivity);
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Goodbye!");
                    session.EndSession();
                    session.DisplayActivitiesSummary();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        do
        {
            DisplayMenu(menuOptions, session);
        } while (true);

    }
}