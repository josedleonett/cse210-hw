using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only Son, that whoever believes in him should not perish but have eternal life."),
            new Scripture(new Reference("Psalm", 23, 1), "The Lord is my shepherd; I shall not want."),
            new Scripture(new Reference("Moroni", 7, 47, 48), "But charity is the pure love of Christ, and it endureth forever; and whoso is found possessed of it at the last day, it shall be well with him. Wherefore, my beloved brethren, pray unto the Father with all the energy of heart, that ye may be filled with this love, which he hath bestowed upon all who are true followers of his Son, Jesus Christ; that ye may become the sons of God; that when he shall appear we shall be like him, for we shall see him as he is; that we may have this hope; that we may be purified even as he is pure. Amen."),
            new Scripture(new Reference("1 Nefi", 3, 7), "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."),
            new Scripture(new Reference("Moroni", 10, 32), "Yea, come unto Christ, and be perfected in him, and deny yourselves of all ungodliness; and if ye shall deny yourselves of all ungodliness, and love God with all your might, mind and strength, then is his grace sufficient for you, that by his grace ye may be perfect in Christ; and if by the grace of God ye are perfect in Christ, ye can in nowise deny the power of God.")
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Choose a scripture to memorize:");
            for (int i = 0; i < scriptures.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {scriptures[i].GetReferenceText()}");
            }
            Console.WriteLine("[+] to add your own Scripture.");
            Console.WriteLine("[0] to close the program.");
            Console.Write("Enter the number of the scripture you would like to memorize: ");

            string choice = Console.ReadLine();

            if (choice == "0")
            {
                return;
            }

            if (choice == "+")
            {
                AddScripture(scriptures);
                continue;
            }

            if (!int.TryParse(choice, out int selectedIndex) || selectedIndex < 1 || selectedIndex > scriptures.Count)
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and " + scriptures.Count);
                continue;
            }

            Scripture selectedScripture = scriptures[selectedIndex - 1];
            MemorizeScripture(selectedScripture);
        }
    }

    static void AddScripture(List<Scripture> scriptures)
    {
        Console.Clear();
        Console.WriteLine("Enter the book of the scripture you would like to memorize: ");
        string book = Console.ReadLine();
        Console.WriteLine("Enter the chapter of the scripture you would like to memorize: ");
        int chapter;
        while (!int.TryParse(Console.ReadLine(), out chapter) || chapter < 1)
        {
            Console.WriteLine("Invalid chapter. Please enter a number greater than 0.");
        }
        Console.WriteLine("Enter the start verse of the scripture you would like to memorize: ");
        int verse;
        while (!int.TryParse(Console.ReadLine(), out verse) || verse < 1)
        {
            Console.WriteLine("Invalid verse. Please enter a number greater than 0.");
        }
        Console.WriteLine("Enter the end verse of the scripture you would like to memorize (Enter 0 if not there): ");
        int endVerse;
        while (!int.TryParse(Console.ReadLine(), out endVerse) || endVerse < 0)
        {
            Console.WriteLine("Invalid verse. Please enter a number.");
        }
        Console.WriteLine("Enter the text of the scripture you would like to memorize: ");
        string text = Console.ReadLine();

        if (endVerse == 0)
        {
            scriptures.Add(new Scripture(new Reference(book, chapter, verse), text));
            return;
        }
        else
        {
            scriptures.Add(new Scripture(new Reference(book, chapter, verse, endVerse), text));
            return;
        }
    }

    static void MemorizeScripture(Scripture selectedScripture)
    {
        Random random = new Random();

        do
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine();

            Console.WriteLine("Press enter to continue or type 'quit' to close the program.");
            string input = Console.ReadLine();

            if (input == "quit" || selectedScripture.IsComplete())
            {
                break;
            }

            int randomWordsToHide = random.Next(1, 5);
            selectedScripture.HideRandomWords(randomWordsToHide);
        }
        while (true);
    }
}