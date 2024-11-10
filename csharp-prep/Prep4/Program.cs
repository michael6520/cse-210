using System;
using System.Linq;
using System.Security.Cryptography;

class Program {
    static void Main(string[] args) {
        List<int> numbers = new List<int>();

        while (true) {
            Console.Write("Enter a number (type \"0\" when you're done): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int number)) {
                if (number == 0) break;
                else numbers.Add(number);
            }
            else Console.WriteLine("Invalid input, try again.");
        }

        if (numbers.Count == 0) {
            Console.WriteLine("No numbers were entered.");
            return;
        }

        numbers.Sort();

        int sum = 0;
        foreach (int number in numbers) sum += number;

        float average = (float)sum / numbers.Count;

        int largest = numbers.Last();

        int smallest_positive = numbers.Where(n => n > 0).DefaultIfEmpty(-1).Min();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
        if (smallest_positive == -1) Console.WriteLine($"There are no positive numbers");
        else Console.WriteLine($"The smallest positive number is: {smallest_positive}");
        Console.WriteLine("Sorted List: " + string.Join(", ", numbers));
    }
}