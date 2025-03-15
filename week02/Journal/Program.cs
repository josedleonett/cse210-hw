using System;

class Program
{
    static void Main(string[] args)
    {
        // As creativity requeriment I added improvements to the Save Journal and Load Journal options.
        // I added a confirmation to save the journal and a message to inform the user that the journal was saved.
        // I also added a message to inform the user that the journal was not saved if the user did not confirm the save.
        // I added a message to inform the user that the journal was not found if the file does not exist.

        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Write Entry");
            Console.WriteLine("2. Display Entries");
            Console.WriteLine("3. Save Journal");
            Console.WriteLine("4. Load Journal");
            Console.WriteLine("5. Exit");
            Console.Write("What would you like to do: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Entry entry = new Entry();
                    Console.WriteLine(entry._prompt);
                    Console.Write("Write your entry: ");
                    entry._response = Console.ReadLine();
                    journal.WriteEntry(entry);
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    Console.WriteLine("Are you sure you want to save the journal? yes/no");
                    string confirmation = Console.ReadLine();

                    if (confirmation != "yes")
                    {
                        Console.WriteLine("Journal not saved.");
                        break;
                    }

                    Console.WriteLine("Enter filename to save journal: ");
                    string filenameToSave = Console.ReadLine();
                    journal.SaveJournal(filenameToSave);
                    Console.WriteLine("Journal saved to " + filenameToSave);
                    break;

                case "4":
                    Console.WriteLine("Enter filename to load journal: ");
                    string filenameToLoad = Console.ReadLine();
                    journal.LoadJournal(filenameToLoad);
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}