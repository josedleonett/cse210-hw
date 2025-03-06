using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int randomMagicNumber = random.Next(1, 101);
        bool isGuessed = false;
        int guessCount = 0;

        do
        {
            Console.WriteLine($"What is the magic number? {randomMagicNumber}");

            Console.Write("What is your guess? ");
            int guess = int.Parse(Console.ReadLine());

            if (guess == randomMagicNumber)
            {
                Console.WriteLine("You guessed it!");
                isGuessed = true;
            }
            else if (guess > randomMagicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("Higher");
            }

            guessCount++;

            if (isGuessed)
            {
                Console.WriteLine($"You guessed the magic number in {guessCount} tries.");

                Console.Write("Do you want to play again? (type 'yes' to keep playing) ");
                string playAgain = Console.ReadLine();

                if (playAgain == "yes")
                {
                    randomMagicNumber = random.Next(1, 101);
                    guessCount = 0;
                    isGuessed = false;
                }
            }

        } while (!isGuessed);


    }
}