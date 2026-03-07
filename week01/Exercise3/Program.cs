using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain;
        Random randomGenerator = new Random();

        do
        {
            int magicNumber = randomGenerator.Next(1, 101);
            int guess = -1;
            int guessCount = 0;

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();
                guess = int.Parse(input);
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            Console.WriteLine($"You guessed it in {guessCount} guesses.");
            Console.Write("Do you want to play again (yes/no)? ");
            playAgain = Console.ReadLine().ToLower();
        } while (playAgain == "yes");
    }
}
