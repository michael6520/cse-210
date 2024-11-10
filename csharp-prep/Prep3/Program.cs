using System;

class Program {
    static void Main(string[] args) {
        Random rng = new Random();
        bool playAgain = true;

        while (playAgain) {
            int magic_number = rng.Next(1, 101);
            int guess = -1;
            int counter = 0;

            while (guess != magic_number) {
                counter++;
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out guess)) {
                    if (magic_number > guess) Console.WriteLine("Higher");
                    else if (magic_number < guess) Console.WriteLine("Lower");
                }
                else Console.WriteLine("Invalid input, please enter a valid number.");
            }

            Console.WriteLine($"Correct! The number was {magic_number}, and it took you {counter} guesses to get it right!");

            playAgain = AskToPlayAgain();
        }

        Console.WriteLine("Thanks for playing!");
    }

    static bool AskToPlayAgain()
    {
        while (true)
        {
            Console.Write("Would you like to play again? Type \"Yes\" or \"No\": ");
            string answer = Console.ReadLine().ToLower();

            if (answer == "yes") return true;
            else if (answer == "no") return false;
            else Console.WriteLine("Invalid input. Please type \"Yes\" or \"No\".");
        }
    }
}